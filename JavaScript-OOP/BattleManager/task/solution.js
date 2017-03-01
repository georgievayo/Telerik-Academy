function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    const VALIDATOR = {
        validateNameLength: function (name, min, max) {
            if (name.length < min || name.length > max) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
        },
        validateNameType: function (name) {
            if (typeof name !== 'string') {
                throw Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
        },
        validateNameSymbols: function (name) {
            if (!/^[A-Za-z\s]+$/.test(name)) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        validateManaCost: function (mana) {
            if (typeof mana !== 'number' || mana <= 0 || mana !== (mana | 0)) {
                throw Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        validateEffect: function (effect) {
            if (typeof effect !== 'function' || effect.length !== 1) {
                throw Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
        },
        validateUnitName: function (name) {

            if (name.match(/[^a-zA-Z ]/)) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        validateAlignment: function (alignment) {
            if (typeof alignment !== 'string' || (alignment !== 'good' && alignment !== 'evil' && alignment !== 'neutral')) {
                throw Error("Alignment must be good, neutral or evil!");
            }
        },
        validateDamage: function (damage) {
            if (typeof damage !== 'number' || damage < 0 || damage > 100) {
                throw Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        validateHealth: function (health) {
            if (typeof health !== 'number' || health < 0 || health > 200) {
                throw Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
        },
        validateCount: function (count) {
            if (typeof count !== 'number' || count < 0) {
                throw Error(ERROR_MESSAGES.INVALID_COUNT);
            }
        },
        validateSpeed: function (speed) {
            if (typeof speed !== 'number' || speed < 1 || speed > 100) {
                throw Error(ERROR_MESSAGES.INVALID_SPEED);
            }
        }
    }

    const generateId = (function () {
        let counter = 0;
        return function () {
            counter += 1;
            return counter;
        };
    })();

    // your implementation goes here
    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        set name(x) {
            VALIDATOR.validateNameLength(x, 2, 20);
            VALIDATOR.validateNameSymbols(x);
            VALIDATOR.validateNameType(x);
            this._name = x;
        }
        get name() {
            return this._name;
        }

        set manaCost(x) {
            VALIDATOR.validateManaCost(x);
            this._manaCost = x;
        }
        get manaCost() {
            return this._manaCost;
        }

        set effect(x) {
            VALIDATOR.validateEffect(x);
            this._effect = x;
        }
        get effect() {
            return this._effect;
        }
    }


    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        set name(x) {
            VALIDATOR.validateNameLength(x, 2, 20);
            VALIDATOR.validateNameType(x);
            VALIDATOR.validateUnitName(x);
            this._name = x;
        }
        get name() {
            return this._name;
        }

        set alignment(x) {
            VALIDATOR.validateAlignment(x);
            this._alignment = x;
        }
        get alignment() {
            return this._alignment;
        }
    }


    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);
            this._id = generateId();
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get id() {
            return this._id;
        }

        set damage(x) {
            VALIDATOR.validateDamage(x);
            this._damage = x;
        }
        get damage() {
            return this._damage;
        }

        set health(x) {
            VALIDATOR.validateHealth(x);
            this._health = x;
        }
        get health() {
            return this._health;
        }

        set count(x) {
            VALIDATOR.validateCount(x);
            this._count = x;
        }
        get count() {
            return this._count;
        }

        set speed(x) {
            VALIDATOR.validateSpeed(x);
            this._speed = x;
        }
        get speed() {
            return this._speed;
        }
    }


    class Commander extends Unit {
        constructor(name, alignment, mana, spellbook, army) {
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        set mana(x) {
            VALIDATOR.validateManaCost(x);
            this._mana = x;
        }
        get mana() {
            return this._mana;
        }

        set spellbook(x) {
            this._spellbook = x;
        }
        get spellbook() {
            return this._spellbook;
        }

        set army(x) {
            this._army = x;
        }
        get army() {
            return this._army;
        }
    }

    let commanders = [];
    const battlemanager = {
        getCommander: function (name, alignment, mana) {
            return new Commander(name, alignment, mana);
        },

        getArmyUnit: function (options) {
            return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
        },

        getSpell: function (name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        },

        addCommanders: function (...commander) {
            commanders.push(...commander);
            return this;
        },

        addArmyUnitTo: function (commanderName, armyUnit) {
            commanders.find(x => x.name === commanderName).army.push(armyUnit);
           
            return this;
        },

        addSpellsTo: function (commanderName, ...spell) {

            spell.forEach(function (element) {
                if ((element._name === undefined || element._manaCost === undefined || element._effect === undefined)) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);

                }
                else {
                    VALIDATOR.validateNameLength(element.name, 2, 20);
                    VALIDATOR.validateNameSymbols(element.name);
                    VALIDATOR.validateNameType(element.name);
                    VALIDATOR.validateManaCost(element.manaCost);
                    VALIDATOR.validateEffect(element.effect);
                }

            });
            const index = commanders.findIndex(x => x.name === commanderName);
            commanders[index].spellbook.push(...spell);
        
            return this;
        },

        findCommanders: function (query) {
            let result = [];
            if (query.name !== undefined && query.alignment !== undefined) {
                result = commanders.filter(x => x.name === query.name && x.alignment === query.alignment);
            }
            else if (query.name !== undefined) {
                result = commanders.filter(x => x.name === query.name);
            }
            else {
                result = commanders.filter(x => x.alignment === query.alignment);
            }
            result.sort((a, b) => a.name < b.name ? -1 : 1);
            return result;
        },

        findArmyUnitById: function (id) {
            let result = [];
            commanders.forEach(function (element) {
                const armyUnit = element.army.filter(x => x.id === id);
                if(result.indexOf(armyUnit) < 0) {
                result.push(armyUnit);              

                }
            });
            return result;
        },

        findArmyUnits: function (query) {
            let result = [];
            
            commanders.forEach(function (element) {
                element.army.forEach(function (armyUnit) {
                    if(query.id !== undefined && query.name === undefined && query.alignment === undefined){
                        if(armyUnit.id === query.id){
                            result.push(armyUnit);
                        }
                    }
                    else if(query.id !== undefined && query.name !== undefined && query.alignment === undefined){
                        if(armyUnit.id === query.id && armyUnit.name === query.name){
                            result.push(armyUnit);
                        }
                    }
                    else if(query.id !== undefined && query.name === undefined && query.alignment !== undefined){
                        if(armyUnit.id === query.id && armyUnit.alignment === query.alignment){
                            result.push(armyUnit);
                        }
                    }
                    else if(query.id !== undefined && query.name !== undefined && query.alignment !== undefined){
                        if(armyUnit.id === query.id && armyUnit.name === query.name && armyUnit.alignment === query.alignment){
                            result.push(armyUnit);
                        }
                    }
                    else if(query.id === undefined && query.name !== undefined && query.alignment === undefined){
                        if(armyUnit.name === query.name){
                            result.push(armyUnit);
                        }
                    }
                    else if(query.id === undefined && query.name !== undefined && query.alignment !== undefined){
                        if(armyUnit.alignment === query.alignment && armyUnit.name === query.name){
                            result.push(armyUnit);
                        }
                    }
                    else if(query.id === undefined && query.name === undefined && query.alignment !== undefined){
                        if(armyUnit.alignment === query.alignment){
                            result.push(armyUnit);
                        }
                    }
                    else{
                            result.push(armyUnit);                        
                    }

                });
            });
            result.sort(function (a, b) {
                if (a.speed > b.speed) {
                    return -1;
                }
                else if (a.speed < b.speed) {
                    return 1;
                }
                else {
                    if (a.name < b.name) {
                        return -1;
                    }
                    else {
                        return 1;
                    }
                }
            });
            return result;
        },

        spellcast: function (casterName, spellName, targetUnitId) {
            const commander = commanders.find(x => x.name === casterName);
            if (!(commander instanceof Commander)) {
                throw Error('Can\'t cast with non-existant commander ' + casterName + '!');
            }
            const spell = commander.spellbook.find(x => x.name === spellName);
            if (!(spell instanceof Spell)) {
                throw Error(casterName + ' doesn\'t know ' + spellName);
            }
            if (commander.mana < spell.manaCost) {
                throw Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
            }
            let unit = battlemanager.findArmyUnitById(targetUnitId);
            if (unit === undefined) {
                throw Error(ERROR_MESSAGES.TARGET_NOT_FOUND);
            }
            spell.effect(unit);
            commander.mana = commander.mana - spell.manaCost;
            return this;
        },

        battle: function (attacker, defender) {
            if (attacker.health === undefined || attacker.damage === undefined || attacker.count === undefined ||
                defender.health === undefined || defender.damage === undefined && defender.count === undefined) {
                throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }
            const attackerTotalDamage = attacker.damage * attacker.count;
            let defenderTotalHealth = defender.health * defender.count;
            defenderTotalHealth -= attackerTotalDamage;
            if (defenderTotalHealth < 0) {
                defender.count = 0;
            }
            else {
                defender.count = Math.ceil(defenderTotalHealth / defender.health);

            }
            return this;
        }
    };

    return battlemanager;
}
module.exports = solve;
