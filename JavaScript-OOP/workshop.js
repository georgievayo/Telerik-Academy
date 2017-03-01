function solve() {

	const generateId = (function () {
		let counter = 0;
		return function () {
			counter += 1;
			return counter;
		};
	})();

	function validateString(str) {
		if (str.length < 3 || str.lenngth > 25) {
			throw Error();
		}
	}

	class Playable {
		constructor(title, author) {
			this._id = generateId();
			this.title = title;
			this.author = author;
		}
		set title(x) {
			validateString(x);
			this._title = x;
		}
		get title() {
			return this._title;
		}
		set author(x) {
			validateString(x);
			this._author = x;
		}
		get author() {
			return this._author;
		}
		get id() {
			return this._id;
		}
		play() {
			return '[' + this.id + ']. [' + this.title + '] - [' + this.author + '] ';
		}
	}

	class Audio extends Playable {
		constructor(title, author, length) {
			super(title, author);
			this.length = length;
		}

		set length(x) {
			if (x > 0) {
				this._length = x;
			}
			else {
				throw Error();
			}
		}

		get length() {
			return this._length;
		}
		play() {
			return super.play() + '- [' + this.length + ']';
		}
	}

	class Video extends Playable {
		constructor(title, author, imdbRating) {
			super(title, author);
			this.imdbRating = imdbRating;
		}

		set imdbRating(x) {
			if (x < 1 || x > 5) {
				throw Error();
			}
			this._imdbRating = x;
		}
		get imdbRating() {
			return this._imdbRating;
		}
		play() {
			return super.play() + '- [' + this.imdbRating + ']';
		}
	}
	class Playlist {
		constructor(name) {
			this._id = generateId();
			this.name = name;
			this.playables = [];
		}

		get id() {
			return this._id;
		}

		get name() {
			return this._name;
		}
		set name(x) {
			validateString(x);
			this._name = x;
		}
		get playables() {
			return this._playables;
		}
		set playables(x) {
			this._playables = x;
		}

		addPlayable(playable) {
			this.playables.push(playable);
			return this;
		}

		getPlayableById(id) {
			let result = this.playables.find(p => p.id === id);
			if (result != undefined) {
				return result;
			}
			return null;
		}
		removePlayable(id) {
			if (typeof id !== 'number') {
				let index = this.playables.findIndex(p => p.id === id.id);
				if (index < 0) {
					throw Error();
				}
				this.playables.splice(index, 1);
			}
			else {
				let index = this.playables.findIndex(p => p.id === id);
				if (index < 0) {
					throw Error();
				}
				this.playables.splice(index, 1);
			}
			return this;


		}
		// removePlayable(playable) {
		// 	let index = this.playables.findIndex(p => p.id === playable.id);
		// 	if (index < 0) {
		// 		throw Error();
		// 	}
		// 	this.playables.splice(index, 1);
		// 	return this;
		// }
		listPlayables(page, size) {
			const len = this.playables.length;
			if (page * size >= len || page < 0 || size <= 0) {
				throw Error();
			}
			if (len < size) {
				return this.playables;
			}

			this.playables = this.playables.sort((a, b) => a.title < b.title ? a : b);
			this.playables = this.playables.sort((a, b) => a.id < b.id ? a : b);
			let result = [];
			const finalIndex = (page + 1) * size - 1;
			// for (let i = page * size; i <= finalIndex; i++) {
			// 	result.push(this.playables[i]);
			// }
			return this.playables.slice(page * size, finalIndex + 1);
		}
	}

	function validatePlaylist(playlist) {
		if (typeof playlist !== Playlist) {
			throw Error();
		}
	}

	class Player {
		constructor(name) {
			this.name = name;
			this.playlists = [];
		}
		get name() {
			return this._name;
		}
		set name(x) {
			validateString(x);
			this._name = x;
		}

		get playlists() {
			return this._playlists;
		}

		set playlists(x) {
			this._playlists = x;
		}

		addPlaylist(playlistToAdd) {
			validatePlaylist(playlistToAdd);
			this.playlists.push(playlistToAdd);
			return this;
		}
		getPlaylistById(id) {
			const playlist = this.playlists.find(p => p.id == id);
			if (playlist != undefined) {
				return playlist;
			}
			return null;
		}
		removePlaylist(id) {
			const index = this.playlists.findIndex(p => p.id == id);
			if (index < 0) {
				throw Error();
			}
			else {
				this.playlists.splice(index, 1);
			}
			return this;
		}
		removePlaylist(playlist) {
			const index = this.playlists.findIndex(p => p.id == playlist.id);
			if (index < 0) {
				throw Error();
			}
			else {
				this.playlists.splice(index, 1);
			}
			return this;
		}
		listPlaylists(page, size) {
			const len = this.playlists.length;
			if (page * size >= len || page < 0 || size <= 0) {
				throw Error();
			}

			if (len < size) {
				return this.playlists;
			}

			let result = new Array(size);
			const finalIndex = (page + 1) * size - 1;
			for (let i = page * size; i < finalIndex; i++) {
				result.push(this.playlists[i]);
			}
			// TODO
			return result;
		}

	}

	const module = {
		getPlayer: function (name) {
			return new Player(name);
		},
		getPlaylist: function (name) {
			return new Playlist(name);
		},
		getAudio: function (title, author, length) {
			return new Audio(title, author, length);
		},
		getVideo: function (title, author, imdbRating) {
			return new Video(title, author, imdbRating);
		}
	};

	return module;
}

module.exports = solve;
