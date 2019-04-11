//Import Video Library
import processing.video.*;

Capture video;

int videoScale = 10;
int cols, rows;

void setup(){
  size(640,480);
  cols = width/videoScale;
  rows = height/videoScale;
  video = new Capture(this, cols, rows);
  video.start();

  //printArray(Capture.list());

}

//Read image from camera.
void captureEvent(Capture video){
  video.read();
}

void draw(){
  background(0);
  video.loadPixels();
  
    // Begin loop for columns
  for (int i = 0; i < cols; i++) {
    
  // Begin loop for rows
  for (int j = 0; j < rows; j++) {
    
  // Scaling up to draw a rectangle at (x,y)
  int x = i*videoScale;
  int y = j*videoScale;
  
  int loc = (video.width - i - 1) + j * video.width;
  
  color c = video.pixels[loc];
  float sz = (brightness(c)/255) * videoScale;
  
  rectMode(CENTER);
  fill(255);
  noStroke();
  rect(x + videoScale/2, y + videoScale/2, sz, sz);
  }
  }
    
  //tint();
  //image(video, width/2, height/2, width, height);
}
