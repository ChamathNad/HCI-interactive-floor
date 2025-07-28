let video;
let poseNet;

const part = 16;

let noseX = 0;
let noseY = 0;

const options = {
	detectionType: 'multiple',
}


var ws = new WebSocket("ws://localhost:8765");

function setup() {  
    createCanvas(640, 480);
    video = createCapture(VIDEO);
    video.hide();
    //poseNet = ml5.poseNet(video, modelReady);
    poseNet = ml5.poseNet(video, modelReady);
    poseNet.on('pose', gotPoses);
}

function draw() {
    image(video, 0, 0);

    fill(255, 0, 0);
    noStroke();
    ellipse(noseX, noseY, 20);
  }

function gotPoses(poses) {
	noseX = -99;
	noseY = -99;
    if (poses.length > 0){
        noseX = poses[0].pose.keypoints[part].position.x;
        noseY = poses[0].pose.keypoints[part].position.y;
        obj = JSON.stringify({
            x: noseX,
            y: noseY
        })
		
    }
  }

function modelReady() {
    console.log('model ready');
  }


ws.onopen = function () {
    setInterval(() => {
        ws.send(obj);
    }, 500)
};

ws.onclose = function () {

    // websocket is closed.
    alert("Connection is closed...");
};
