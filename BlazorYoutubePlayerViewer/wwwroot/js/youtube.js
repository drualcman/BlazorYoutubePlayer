(function () {
    youtubeApi = {
        // 2. This code loads the IFrame Player API code asynchronously.
        loadIFramePlayer: () => {
            var tag = document.createElement('script');

            tag.src = "https://www.youtube.com/iframe_api";
            var firstScriptTag = document.getElementsByTagName('script')[0];
            firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
        },
        payVideo: (video) => {
            onPlayVideoReady(() => {
                player.loadVideoById(video)
            });
        },
        stopVideo: () => stopVideo()
    }
})();

// 3. This function creates an <iframe> (and YouTube player)
//    after the API code downloads.
var player;
function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: 'J8fFVOoqepc',
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });
}

// 4. The API will call this function when the video player is ready.
function onPlayerReady(event) {
    event.target.playVideo();
}

// 5. The API calls this function when the player's state changes.
//    The function indicates that when playing a video (state=1),
//    the player should play for six seconds and then stop.
var done = false;
function onPlayerStateChange(event) {
    if (event.data == YT.PlayerState.PLAYING && !done) {
        setTimeout(stopVideo, 6000);
        done = true;
    }
}
function stopVideo() {
    player.stopVideo();
}


window.onPlayVideoReady = (callback, interval = 250, maxWaitDuration = 50000) => {
    const appInterval = setInterval(() => {
        if (window.player.loadVideoById) {
            clearInterval(appInterval);
            callback();
        }
        return
    }, interval)
    setTimeout(() => clearInterval(appInterval), maxWaitDuration)
}