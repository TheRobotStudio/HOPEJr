#include <Arduino.h>

// ─── Multiplexer pins ───────────────────────────────────────────────────
#define S0 5
#define S1 6
#define S2 8
#define S3 7
#define SENSOR_INPUT 4    // analog pin

#define SENSOR_COUNT 16

int rawVals[SENSOR_COUNT];

// scan order through the mux
uint8_t scanOrder[SENSOR_COUNT] = {
  7,6,5,4,3,2,1,0,
  15,14,13,12,11,10,9,8
};

// which rawVals[] indices form each sin/cos pair
const uint8_t anglePairs[5][2] = {
  {2,  3},   // sensor 1
  {5,  6},   // sensor 2
  {10, 11},  // sensor 3
  {12, 13},  // sensor 4a
  {14, 15}   // sensor 5
};

void selectMuxChannel(uint8_t channel) {
  digitalWrite(S0, channel & 0x01);
  digitalWrite(S1, (channel >> 1) & 0x01);
  digitalWrite(S2, (channel >> 2) & 0x01);
  digitalWrite(S3, (channel >> 3) & 0x01);
}

void measureRawValues() {
  for (uint8_t i = 0; i < SENSOR_COUNT; i++) {
    uint8_t ch = scanOrder[i];
    selectMuxChannel(ch);
    delayMicroseconds(100);
    rawVals[i] = analogRead(SENSOR_INPUT);
  }
}

void setup() {
  Serial.begin(115200);
  pinMode(S0, OUTPUT);
  pinMode(S1, OUTPUT);
  pinMode(S2, OUTPUT);
  pinMode(S3, OUTPUT);
  // initialize to channel 0
  digitalWrite(S0, LOW);
  digitalWrite(S1, LOW);
  digitalWrite(S2, LOW);
  digitalWrite(S3, LOW);
}

void loop() {
  measureRawValues();

  // 1) Print all 16 raw readings
  for (uint8_t i = 0; i < SENSOR_COUNT; i++) {
    Serial.print(rawVals[i]);
    Serial.print(' ');
  }

  // 2) Compute & print each angle as (0 … 3600)
  //    angleDeg = atan2(sin,cos)*180/π → (–180 … +180)
  //    encoded = (angleDeg + 180) * 10 → (0 … 3600)
  for (uint8_t j = 0; j < 5; j++) {
    uint8_t i0 = anglePairs[j][0];
    uint8_t i1 = anglePairs[j][1];
    // normalize raw → –1 … +1
    float sinv = rawVals[i0] * 2.0f / 4095.0f - 1.0f;
    float cosv = rawVals[i1] * 2.0f / 4095.0f - 1.0f;
    float deg  = atan2(sinv, cosv) * 180.0f / PI;
    uint16_t enc = uint16_t((deg + 180.0f) * 10.0f);  // truncate
    Serial.print(enc);
    if (j < 4) Serial.print(' ');
  }

  Serial.println();
  delay(1);
}