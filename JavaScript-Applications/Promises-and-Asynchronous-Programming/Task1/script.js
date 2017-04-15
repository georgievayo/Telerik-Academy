
let promise = new Promise((resolve, reject) => {
    navigator.geolocation.getCurrentPosition(position => resolve(position),
        error => reject(error));
});

function addImage(location) {
    let map = document.getElementById('map');
    map.setAttribute('src', 'http://maps.googleapis.com/maps/api/staticmap?center=' + location.latitude + ',' + location.longitude + '&zoom=17&size=500x500&sensor=false');
}

function calculateCoordinates(value) {
    return {
        latitude: value.coords.latitude,
        longitude: value.coords.longitude
    };
}

promise.then(position => addImage(calculateCoordinates(position)));