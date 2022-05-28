
var localStorage = window.localStorage;

function saveToLocalStorage(key, value) {
    console.log("saving to local storage...");
    localStorage.setItem(key, value);
}
function getFromLocalStorage(key) {
    console.log("getting to local storage...");
    var item = localStorage.getItem(key);
    return item;
}
