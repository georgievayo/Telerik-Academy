function solve() {
	// Your classes
	const generateID = (function () {
		let counter = 0;
		return function () {
			counter += 1;
			return counter;
		};
	})();


	const VALIDATOR = {
		validateIsString: function (str) {
			if (typeof str !== 'string') {
				throw Error();
			}
		},
		validateStringLength: function (str, min, max) {
			if (str.length < min || str.length > max) {
				throw Error();
			}
		},
		validatePositiveNumber: function (number) {
			if ((typeof number !== 'number') || number <= 0 || Number.isNaN(number)) {
				throw Error();
			}
		},
		validateNumberInRange: function (number, min, max) {
			if ((typeof number !== 'number') || number < min || number > max || Number.isNaN(number)) {
				throw Error();
			}
		},
		validateIsInteger: function (number) {
			if (!Number.isInteger(number)) {
				throw Error();
			}
		},
		validateQuality: function (quality) {
			if ((typeof quality !== 'string') || (quality !== 'high' && quality !== 'mid' && quality !== 'low')) {
				throw Error();
			}
		},
		validateProduct: function (product) {
			if (!(product instanceof Product)) {
				throw Error();
			}
		}
	};


	class Product {
		constructor(manufacturer, model, price) {
			this._id = generateID();
			this.manufacturer = manufacturer;
			this.model = model;
			this.price = price;
		}
		get id() {
			return this._id;
		}

		set manufacturer(x) {
			VALIDATOR.validateIsString(x);
			VALIDATOR.validateStringLength(x, 1, 20);
			this._manufacturer = x;
		}
		get manufacturer() {
			return this._manufacturer;
		}

		set model(x) {
			VALIDATOR.validateIsString(x);
			VALIDATOR.validateStringLength(x, 1, 20);
			this._model = x;
		}
		get model() {
			return this._model;
		}

		set price(x) {
			VALIDATOR.validatePositiveNumber(x);
			this._price = x;
		}
		get price() {
			return this._price;
		}

		getLabel() {
			const str = this.constructor.name + ' - ' + this.manufacturer + ' ' + this.model + ' - **' + this.price + '**';
			return str;
		}

		getTypeAsString() {
			return this.constructor.name;
		}
	}


	class SmartPhone extends Product {
		constructor(manufacturer, model, price, screenSize, operatingSystem) {
			super(manufacturer, model, price);
			this.screenSize = screenSize;
			this.operatingSystem = operatingSystem;
		}

		set screenSize(x) {
			VALIDATOR.validatePositiveNumber(x);
			this._screenSize = x;
		}
		get screenSize() {
			return this._screenSize;
		}

		set operatingSystem(x) {
			VALIDATOR.validateIsString(x);
			VALIDATOR.validateStringLength(x, 1, 10);
			this._operatingSystem = x;
		}
		get operatingSystem() {
			return this._operatingSystem;
		}

		getLabel() {
			return super.getLabel();
		}

		getTypeAsString() {
			return super.getTypeAsString();
		}
	}

	class Charger extends Product {
		constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
			super(manufacturer, model, price);

			this.outputCurrent = outputCurrent;
			this.outputVoltage = outputVoltage;
		}

		set outputVoltage(x) {
			VALIDATOR.validateNumberInRange(x, 5, 20);
			this._outputVoltage = x;
		}
		get outputVoltage() {
			return this._outputVoltage;
		}

		set outputCurrent(x) {
			VALIDATOR.validateNumberInRange(x, 100, 3000);
			this._outputCurrent = x;
		}
		get outputCurrent() {
			return this._outputCurrent;
		}

		getLabel() {
			return super.getLabel();
		}

		getTypeAsString() {
			return super.getTypeAsString();
		}
	}


	class Router extends Product {
		constructor(manufacturer, model, price, wifiRange, lanPorts) {
			super(manufacturer, model, price);

			this.wifiRange = wifiRange;
			this.lanPorts = lanPorts;
		}

		set wifiRange(x) {
			VALIDATOR.validatePositiveNumber(x);
			this._wifiRange = x;
		}
		get wifiRange() {
			return this._wifiRange;
		}

		set lanPorts(x) {
			VALIDATOR.validatePositiveNumber(x);
			VALIDATOR.validateIsInteger(x);
			this._lanPorts = x;
		}
		get lanPorts() {
			return this._lanPorts;
		}

		getLabel() {
			return super.getLabel();
		}

		getTypeAsString() {
			return super.getTypeAsString();
		}
	}

	class Headphones extends Product {
		constructor(manufacturer, model, price, quality, hasMicrophone) {
			super(manufacturer, model, price);

			this.quality = quality;
			this.hasMicrophone = hasMicrophone;
		}

		set quality(x) {
			VALIDATOR.validateQuality(x);
			this._quality = x;
		}
		get quality() {
			return this._quality;
		}
		set hasMicrophone(x) {
			if (x) {
				this._hasMicrophone = true;
			}
			else {
				this._hasMicrophone = false;
			}

		}
		get hasMicrophone() {
			return this._hasMicrophone;
		}

		getLabel() {
			return super.getLabel();
		}

		getTypeAsString() {
			return super.getTypeAsString();
		}

	}


	class HardwareStore {
		constructor(name) {
			this.moneyAmount = 0;
			this.name = name;
			this._products = [];
		}

		set name(x) {
			VALIDATOR.validateIsString(x);
			VALIDATOR.validateStringLength(x, 1, 20);
			this._name = x;
		}
		get name() {
			return this._name;
		}

		get products() {
			return this._products;
		}

		stock(product, quantity) {
			VALIDATOR.validateProduct(product);
			VALIDATOR.validatePositiveNumber(quantity);
			VALIDATOR.validateIsInteger(quantity);

			//let isAdded = false;

			// this._products.forEach(function (item) {
			// 	if (item.product.manufacturer === product.manufacturer && item.product.model === product.model
			// 		&& item.product.price === product.price && item.product.id === product.id) {
			// 		if ((product instanceof SmartPhone) && (item.product instanceof SmartPhone)) {
			// 			if (item.product.screenSize === product.screenSize && item.product.operatingSystem === product.operatingSystem) {
			// 				item.quantity = item.quantity + quantity;
			// 				isAdded = true;
							
			// 			}
			// 		}
			// 		else if ((product instanceof Charger) && (item.product instanceof Charger)) {
			// 			if (item.product.outputVoltage === product.outputVoltage && item.product.outputCurrent === product.outputCurrent) {
			// 				item.quantity = item.quantity + quantity;
			// 				isAdded = true;
							
			// 			}
			// 		}
			// 		else if ((product instanceof Router) && (item.product instanceof Router)) {
			// 			if (item.product.wifiRange === product.wifiRange && item.product.lanPorts === product.lanPorts) {
			// 				item.quantity = item.quantity + quantity;
			// 				isAdded = true;
							
			// 			}
			// 		}
			// 		else if ((product instanceof Headphones) && (product instanceof Headphones)) {
			// 			if (item.product.quality === product.quality && item.product.hasMicrophone === product.hasMicrophone) {
			// 				item.quantity = item.quantity + quantity;
			// 				isAdded = true;
							
			// 			}
			// 		}
			// 	}

			// });
				const index = this._products.findIndex(x => x.product.id === product.id);
				if(index < 0){
					const productAndQuantity = {
					product: product,
					quantity: quantity
				};
				this._products.push(productAndQuantity);
			}
			else{
				this._products[index].quantity = this._products[index].quantity + quantity;
			}

			return this;
		}

		sell(productID, quantity) {
			VALIDATOR.validatePositiveNumber(quantity);
			VALIDATOR.validateIsInteger(quantity);

			const index = this._products.findIndex(x => x.product.id === productID);
			if (index < 0 || this._products[index].quantity < quantity) {
				throw Error();
			}
			else {
				this.moneyAmount = this.moneyAmount + (this._products[index].product.price * quantity);
				this._products[index].quantity = this._products[index].quantity - quantity;
				if (this._products[index].quantity === 0) {
					//const index = this._products.findIndex(x => x === foundProduct);
					this._products.splice(index, 1);
				}
			}
			return this;
		}

		getSold() {
			return this.moneyAmount;
		}

		search(something) {
			let result = [];
			if (typeof something === 'string') {
				const pattern = new RegExp(something, 'i');
				this._products.forEach(currentProduct => {
					if (pattern.test(currentProduct.product.model) || pattern.test(currentProduct.product.manufacturer)) {
						result.push(currentProduct);
					}
				});
			}
			else if(typeof something === 'object'){
				result = this._products.filter(item => {
					return (
						(!something.hasOwnProperty('manufacturerPattern') || (new RegExp(something.manufacturerPattern)).test(item.product.manufacturer))
						&& (!something.hasOwnProperty('modelPattern') || (new RegExp(something.modelPattern)).test(item.product.model))
						&& (!something.hasOwnProperty('type') || something.type === item.product.getTypeAsString())
						&& (!something.hasOwnProperty('minPrice') || item.product.price >= something.minPrice)
						&& (!something.hasOwnProperty('maxPrice') || item.product.price <= something.maxPrice));
				});
			}
			else{
				throw Error();
			}
			return result;
		}
	}


	return {
		getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
			return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
		},
		getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
			return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
		},
		getRouter(manufacturer, model, price, wifiRange, lanPorts) {
			return new Router(manufacturer, model, price, wifiRange, lanPorts);
		},
		getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
			return new Headphones(manufacturer, model, price, quality, hasMicrophone);
		},
		getHardwareStore(name) {
			return new HardwareStore(name);
		}
	};

}

// Submit the code above this line in bgcoder.com
module.exports = solve; // DO NOT SUBMIT THIS LINE
// const result = solve();

// const phone = result.getSmartPhone('HTC', 'One', 903, 5, 'Android');


// const headphones = result.getHeadphones('Sennheiser', 'PXC 550 Wireless', 340, 'low', null);
// console.log(headphones);
// //console.log(headphones.getLabel());
// const store = result.getHardwareStore('Magazin');
// const router = result.getRouter("typotiq", 'typo', 16, 25, 28);
// const router2 = result.getRouter("typotiq", 'typo', 16, 25, 28);
// const charger = result.getCharger("klfdsjksld", "kfdjsdk", 18, 5, 500);
// store.stock(charger, 34);
// store.sell(charger.id, 34).stock(router, 15).stock(router2, 12);
//console.log(store.products);
// store.stock(router, 17);
// store.stock(headphones, 1);
// store.stock(router2, 14);
// console.log(store.products);

// store.sell(5, 2).sell(3, 1);
// console.log(store.products);
// console.log(store.getSold());
