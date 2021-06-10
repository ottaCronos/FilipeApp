// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function search() {
    let item = document.getElementById("q");
    window.location = "/search?q=" + item.innerText;
}

function SetTitle(title) {
    document.title = title;
}

function SetDescription(desc) {
    document.description = desc;
}

function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

function startAd(source){
    jQuery('.video-js').bind('contextmenu',function() { return false; });
    jQuery('.video-js').bind('click',function() {
        let preloader = document.getElementById('preloader');
        let player = videojs('preloader');
        if (player.currentSrc() !== source){
            var win = window.open("https://haru-anime.me/ad", '_blank');
            win.focus();
        }
    });

    document.onload = setTimeout(function () {
        let preloader = document.getElementById('preloader');
        let player = videojs('preloader');
        player.pause();
        player.src(source);
        player.controls(true);
        player.currentTime(0);
        startWatch();
    }, 12000);
}

function startWatch(){
    jQuery('.video-js').bind('contextmenu', function () { return false; });
    let source = document.getElementById('video_source');
}

MyDOMGetBoundingClientRect = (element, parm) => { return document.getElementById(element).getBoundingClientRect(); };

function setCurrentTime(currentTime){
    var vid = document.getElementById("haru_player");
    vid.currentTime = currentTime;
}

function setVolume(volume){
    var vid = document.getElementById("haru_player");
    vid.volume = volume;
}

function playVideo(){
    var vid = document.getElementById("haru_player");
    vid.play();
}

function pauseVideo(){
    var vid = document.getElementById("haru_player");
    vid.pause();
}

function toggleFullscreen() {
    var element = document.getElementsByClassName('haru-video-container')[0];

    /*if (event instanceof HTMLElement) {
        element = event;
    }*/

    var isFullscreen = document.webkitIsFullScreen || document.mozFullScreen || false;

    element.requestFullScreen = element.requestFullScreen || element.webkitRequestFullScreen || element.mozRequestFullScreen || function () { return false; };
    document.cancelFullScreen = document.cancelFullScreen || document.webkitCancelFullScreen || document.mozCancelFullScreen || function () { return false; };

    isFullscreen ? document.cancelFullScreen() : element.requestFullScreen();
}

function reloadPage(){
    location.reload();
}

function openWindow(url) {
    window.open(url);
}

function openStripe(session){
    var stripe = Stripe("pk_test_51IpWVyDGKVstrj0H30ljRuQPutJgKDI2Mxpn5MjQ3dJGFpHKuJRkBp8T5TlP9zlry2XdFwd28lYJJHwdbGNSpuGK00tVPE7nwo");
    stripe.redirectToCheckout({
            sessionId: session
        })
        .then(handleResult);
}