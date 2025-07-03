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
  digitalWrite(S0, LOW);
  digitalWrite(S1, LOW);
  digitalWrite(S2, LOW);
  digitalWrite(S3, LOW);
}

void loop() {
  measureRawValues();

  for (uint8_t i = 0; i < SENSOR_COUNT; i++) {
    Serial.print(rawVals[i]);
    Serial.print(' ');
  }

  Serial.println();
  delay(1);
}
