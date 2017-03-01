function solve() {

const generateID = (function () {
		let counter = 0;
		return function () {
			counter += 1;
			return counter;
		};
	})();
	
	class Item {
		constructor(description, name) {
			this._id = generateID();
			this.description = description;
			this.name = name;
		}

		get id() {
			return this._id;
		}

		set description(x) {
			if (typeof x !== 'string' || x.length === 0) {
				throw Error();
			}
			else {
				this._description = x;
			}
		}
		get description() {
			return this._description;
		}

		set name(x) {
			if (typeof x !== 'string' || x.length < 2 || x.length > 40) {
				throw Error();
			}
			else {
				this._name = x;
			}
		}
		get name() {
			return this._name;
		}
	}

	class Book extends Item {
		constructor(description, name, isbn, genre) {
			super(description, name);
			this.isbn = isbn;
			this.genre = genre;
		}

		set isbn(x) {
			if (typeof x !== 'string' || !(x.length === 10 || x.length === 13) || !(/^[0-9]+$/).test(x)) {
				throw Error();
			}
			this._isbn = x;
		}
		get isbn() {
			return this._isbn;
		}

		set genre(x) {
			if (typeof x !== 'string' || x.length < 2 || x.length > 20) {
				throw Error();
			}
			this._genre = x;
		}
		get genre() {
			return this._genre;
		}
	}

	class Media extends Item {
		constructor(description, name, duration, rating) {
			super(description, name);
			this.duration = duration;
			this.rating = rating;
		}

		set duration(x) {
			if (typeof x !== 'number' || x <= 0) {
				throw Error();
			}
			this._duration = x;
		}
		get duration() {
			return this._duration;
		}

		set rating(x) {
			if (typeof x !== 'number' || x < 1 || x > 5) {
				throw Error();
			}
			this._rating = x;
		}
		get rating() {
			return this._rating;
		}
	}

	class Catalog {
		constructor(name) {
			this._id = generateID();
			this.name = name;
			this.items = [];
		}

		set name(x) {
			if (typeof x !== 'string' || x.length < 2 || x.length > 40) {
				throw Error();
			}
			else {
				this._name = x;
			}
		}
		get name() {
			return this._name;
		}

		set items(x) {
			this._items = x;
		}
		get items() {
			return this._items;
		}

		get id(){
			return this._id;
		}

		add(...items) {
			if (items.length === 0) {
				throw Error();
			}
			items.forEach(function (item) {
				if (item.id === undefined || item.name === undefined || item.description === undefined) {
					throw Error();
				}
			}, this);

			this.items.push(...items);
			return this;
		}

		find(something) {
			if (something === undefined) {
				throw Error();
			}
			if (typeof something === 'number') {
				const item = this.items.find(x => x.id === id);
				if (item === undefined) {
					return null;
				}
				return item;
			}
			else {
				let result = [];
				if (something.id !== undefined && something.name === undefined) {
					result.push(this.items.find(x => x.id === something.id));
				}
				else if (something.id === undefined && something.name !== undefined) {
					result = this.items.filter(x => x.name === something.name);
				}
				else if (something.id !== undefined && something.name !== undefined) {
					result.push(this.items.find(x => x.name === something.name && x.id === something.id));
				}
				return result;
			}
		}

		search(pattern) {
			if (pattern.length < 1) {
				throw Error();
			}
			let result = [];
			const reg = new RegExp(pattern);
			this.items.forEach(function (item) {
				if (reg.test(item.name) || reg.test(item.description)) {
					result.push(item);
				}
			});
			return result;
		}
	}

	class BookCatalog extends Catalog {
		constructor(name) {
			super(name);
		}
		add(...books) {			
			if (books.length === 0) {
				throw Error();
			}
			if (!(books[0] instanceof Array)) {
				books.forEach(function (item) {
					if (item.id === undefined || item.name === undefined || item.description === undefined ||
						item.genre === undefined || item.isbn === undefined) {
						throw Error();
					}
				});
				this.items.push(...books);
			}
			else {		
				books[0].forEach(function (item) {
					if (item.id === undefined || item.name === undefined || item.description === undefined ||
						item.genre === undefined || item.isbn === undefined) {
						throw Error();
					}
				});
				books[0].forEach(function (book) {
					this.items.push(book);
				}, this);
			}
			return this;
		}

		getGenres() {
			let result = new Array();
			this.items.forEach(function (book) {
				
				if(result.indexOf(x => x === book._genre) === -1){
					result.push(book._genre);
				}
				
			}

			)
			return result;
		}

		find(something) {
			if (something === undefined || something === null || (typeof something === 'string')) {
				throw Error();
			}
			if (typeof something === 'number') {
				const item = this.items.find(x => x.id === something);
				if (item === undefined) {
					return null;
				}
				return item;
			}
			else {
				let result = [];
				if (something.id !== undefined && something.name === undefined && something.genre === undefined) {
					result.push(this.items.find(x => x.id === something.id));
				}
				else if (something.id === undefined && something.name !== undefined && something.genre === undefined) {
					result = this.items.filter(x => x.name === something.name);
				}
				else if (something.id !== undefined && something.name !== undefined && something.genre === undefined) {
					result.push(this.items.find(x => x.name === something.name && x.id === something.id));
				}
				else if (something.id !== undefined && something.name !== undefined && something.genre !== undefined) {
					result.push(this.items.find(x => x.name === something.name && x.id === something.id && x.genre === something.genre));
				}
				else if (something.id === undefined && something.name === undefined && something.genre !== undefined) {
					result.push(this.items.find(x => x.genre === something.genre));
				}
				else if (something.id !== undefined && something.name === undefined && something.genre !== undefined) {
					result.push(this.items.find(x => x.genre === something.genre && x.id === something.id));
				}
				else if (something.id === undefined && something.name !== undefined && something.genre !== undefined) {
					result.push(this.items.find(x => x.name === something.name && x.genre === something.genre));
				}
				return result;
			}
		}
	}

	class MediaCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...media) {
			if (media.length === 0) {
				throw Error();
			}
			if (!(media[0] instanceof Array)) {
				media.forEach(function (item) {
					if (item.id === undefined || item.name === undefined || item.description === undefined ||
						item.duration === undefined || item.rating === undefined) {
						throw Error();
					}
				});
				this.items.push(...media);
			}
			else {
				media[0].forEach(function (item) {
					if (item.id === undefined || item.name === undefined || item.description === undefined ||
						item.duration === undefined || item.rating === undefined) {
						throw Error();
					}
				});
				media[0].forEach(function (book) {
					this.items.push(book);
				}, this);
			}
			return this;
		}

		getTop(count) {
			if (typeof count !== 'number' || count < 1) {
				throw Error();
			}
			this.items.sort((a, b) => a.rating < b.rating ? -1 : 1);
			let result = [];
			if (count > this.items.length) {
				for (let i = 0; i < this.items.length; i++) {
					const obj = {
						id: this.items[i].id,
						name: this.items[i].name
					};
					result.push(obj);
				}
			}
			else {
				for (let i = 0; i < count; i++) {
					const obj = {
						id: this.items[i].id,
						name: this.items[i].name
					};
					result.push(obj);
				}
			}

			return result;
		}

		getSortedByDuration() {
			this.items.sort(function (a, b) {
				if (a.duration > b.duration) {
					return -1;
				}
				else if (a.duration < b.duration) {
					return 1;
				}
				else {
					if (a.id < b.id) {
						return -1;
					}
					else {
						return 1;
					}
				}
			})
			return this.items;
		}

		find(something) {
			if (something === undefined || (typeof something === 'string')) {
				throw Error();
			}
			if (typeof something === 'number') {
				const item = this.items.find(x => x.id === something);
				if (item === undefined) {
					return null;
				}
				return item;
			}
			else {
				let result = [];
				if (something.id !== undefined && something.name === undefined && something.rating === undefined) {
					result.push(this.items.find(x => x.id === something.id));
				}
				else if (something.id === undefined && something.name !== undefined && something.rating === undefined) {
					result = this.items.filter(x => x.name === something.name);
				}
				else if (something.id !== undefined && something.name !== undefined && something.rating === undefined) {
					result.push(this.items.find(x => x.name === something.name && x.id === something.id));
				}
				else if (something.id !== undefined && something.name !== undefined && something.rating !== undefined) {
					result.push(this.items.find(x => x.name === something.name && x.id === something.id && x.rating === something.rating));
				}
				else if (something.id === undefined && something.name === undefined && something.rating !== undefined) {
					result.push(this.items.find(x => x.rating === something.rating));
				}
				else if (something.id !== undefined && something.name === undefined && something.rating !== undefined) {
					result.push(this.items.find(x => x.rating === something.rating && x.id === something.id));
				}
				else if (something.id === undefined && something.name !== undefined && something.rating !== undefined) {
					result.push(this.items.find(x => x.name === something.name && x.rating === something.rating));
				}
				return result;
			}
		}
	}
	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(description, name, isbn, genre);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(description, name, duration, rating);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};

}

module.exports = solve;

// let book = solve().getBook('Toskana', '1234567890', 'Romance', 'Love story');
// let book1 = solve().getBook('Opera', '1234567890', 'Mystery', 'Mystery story');

// let arr = [];
// arr.push(book);
// arr.push(book1);

// let catalog = solve().getBookCatalog('Catalogue');
// catalog.add(arr);
// console.log(catalog.search('ory'));


