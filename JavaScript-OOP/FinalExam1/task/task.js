function solve() {
	// Your classes
	const validator = {
		validateName: function (name, min, max) {
			const pattern = /[A-Za-z0-9 ]{1,}/g;
			if (typeof name !== 'string' || name.length < min || name.length > max || !pattern.test(name)) {
				throw Error();
			}
		},
		validateHostname: function(name, min,max){
			if (typeof name !== 'string' || name.length < min || name.length > max) {
				throw Error();
			}
		},
		validateVersion: function (version) {
			if (typeof version !== "number" || version < 0) {
				throw Error();
			}
		},
		validateRating: function (rating) {
			if (typeof rating !== 'number' || rating < 1 || rating > 10) {
				throw Error();
			}
		},
		validateDescription: function (description) {
			if (typeof description !== 'string') {
				throw Error();
			}
		},
		validateApp: function (app) {
			if (!(app instanceof App)) {
				throw Error();
			}
		}
	};

	class App {
		constructor(name, description, version, rating) {
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
		}

		set timeOfUpload(x) {
			this._timeOfUpload = x;
		}
		get timeOfUpload() {
			return this._timeOfUpload;
		}

		set name(x) {
			validator.validateName(x, 1, 24);
			this._name = x;
		}
		get name() {
			return this._name;
		}

		set description(x) {
			validator.validateDescription(x);
			this._description = x;
		}
		get description() {
			return this._description;
		}

		set version(x) {
			validator.validateVersion(x);
			this._version = x;
		}
		get version() {
			return this._version;
		}

		set rating(x) {
			validator.validateRating(x);
			this._rating = x;
		}
		get rating() {
			return this._rating;
		}

		release(something) {
			if (typeof something === 'number') {
				if (something <= this.version) {
					throw Error();
				}
				this.version = something;
			}
			else {
				if (something.version === undefined || something.version < this.version) {
					throw Error();
				}
				validator.validateVersion(something.version);
				this.version = something.version;
				if (something.description !== undefined) {
					
					this.description = something.description;
				}
				if (something.rating !== undefined) {
					
					this.rating = something.rating;
				}
			}
			return this;
		}
	}

	const generateTime = (function () {
		let counter = 0;
		return function () {
			counter += 1;
			return counter;
		};
	})();

	class Store extends App {
		constructor(name, description, version, rating) {
			super(name, description, version, rating);
			this.apps = [];
		}

		set apps(x) {
			this._apps = x;
		}
		get apps() {
			return this._apps;
		}

		uploadApp(app) {
			validator.validateApp(app);
			const index = this.apps.findIndex(a => a.name === app.name);
			if (index >= 0) {
				const options = {
					version: app.version,
					description: app.description,
					rating: app.rating
				};
				this.apps[index].release(options);
				this.apps[index].timeOfUpload = generateTime();
			}
			else {
				app.timeOfUpload = generateTime();
				this.apps.push(app);				
			}

			return this;
		}

		takedownApp(name) {
			const index = this.apps.findIndex(a => a.name === name);
			if (index < 0) {
				throw Error();
			}
			this.apps.splice(index, 1);
			return this;
		}

		search(pattern) {
			let result = [];
			this.apps.forEach(function (element) {
				if (element.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0) {
					result.push(element);
				}
			});
			result.sort(function(a, b){
				if(a.name < b.name){
					return -1;
				} 
				else{
					return 1;
				}
			});
			return result;
		}

		listMostRecentApps(count) {
			count = count || 10;
			this.apps.sort((a,b) => a.timeOfUpload >= b.timeOfUpload ? -1 : 1)
			let result = this.apps;
			return result.slice(0, count);
		}

		listMostPopularApps(count) {
			count = count || 10;
			
			let result = [];
			this.apps.sort(function (a, b) {
				if (a.rating > b.rating) {
					return -1;
				}
				else if (a.rating < b.rating) {
					return 1;
				}
				else {
					if(a.timeOfUpload > b.timeOfUpload){
						return -1;
					}
					else{
						return 1;
					}
				}
			});
			result = this.apps.slice(0, count);
			return result;
		}
	}

	class Device {
		constructor(hostname, preinstalledApps) {
			this.hostname = hostname;
			this.apps = preinstalledApps;
		}

		set hostname(x) {
			validator.validateHostname(x, 1, 32);
			this._hostname = x;
		}
		get hostname() {
			return this._hostname;
		}

		set apps(x) {
			x.forEach(function (element) {
				validator.validateApp(element);
			});
			this._apps = x;
		}

		get apps() {
			return this._apps;
		}

		search(pattern) {
			let result = [];
			this.apps.forEach(function (element) {
				if ( element instanceof Store) {
					element.apps.forEach(function (app) {
						if (app.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0) {
							const index = result.indexOf(app);
							if(index < 0){
								result.push(app);
							}
							else{
								result[index].release(app);
							}
						}
					});
				}
			});
			result.sort((a, b) => a.name < b.name ? -1 : 1);
			return result;
		}

		install(name) {
			// check if the app is already install
			const index = this.apps.findIndex(a => a.name === name);
			if (index < 0) {
				// if the app is not already install
				let result = [];
				this.apps.forEach(function (element) {
					if (element instanceof Store) {
						element.apps.forEach(function (app) {
							if (app.name === name) {
								result.push(app);
							}
						});
					}
				});
				if (result.length === 0) {
					throw Error();
				}
				result.sort((a, b) => a.version > b.version ? -1 : 1);
				this.apps.push(new App(name, result[0].description, result[0].version, result[0].rating));
			}

			return this;
		}

		uninstall(name) {
			const index = this.apps.findIndex(a => a.name === name);
			if (index < 0) {
				throw Error();
			}
			else {
				this.apps.splice(index, 1);
			}
			return this;
		}

		listInstalled() {
			this.apps.sort((a, b) => a.name < b.name ? -1 : 1);
			return this.apps;
		}

		update() {
			// get stores
			let stores = [];
			this.apps.forEach(function(element) {
				if(element instanceof Store){
					stores.push(element);
				}
			});

			// foreach app in apps
			this.apps.forEach(function(element) {
				// if element is app
				if(!(element instanceof Store)){
					//foreach store in stores
					stores.forEach(function(store) {
						let index = store.apps.findIndex(a => a.name === element.name);
						if(index >= 0){
							// if there is an app in a store with newer version
							if(store.apps[index].version > element.version){
								
								element.release(store.apps[index]);
							}
						}
					});
				}
			});
			console.log(this.apps)
			return this;
		}
	}


	return {
		createApp(name, description, version, rating) {
			return new App(name, description, version, rating);
		},
		createStore(name, description, version, rating) {
			return new Store(name, description, version, rating);
		},
		createDevice(hostname, apps) {
			return new Device(hostname, apps);
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve;
