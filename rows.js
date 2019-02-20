window.onload = function(){
	setInterval(fSec, 800);

	function fSec(){
        var parentElem  = document.getElementById('dev_1');
var newDiv = document.createElement('div');
newDiv.className = "alert";
  newDiv.innerHTML = 'Привет, мир!';
  parentElem.appendChild(newDiv)
    }
    
}