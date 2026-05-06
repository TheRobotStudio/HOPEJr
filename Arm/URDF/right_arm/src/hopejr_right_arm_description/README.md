# hopejr_right_arm_description

## Usage
Create a new workspace and clone this library:
```shell
mkdir hopejr_right_arm
cd hopejr_right_arm
mkdir src
cd src
git clone https://github.com/song-jisu/hopejr_arm_description.git
git clone https://github.com/song-jisu/hopejr_hand_description.git
git clone https://github.com/song-jisu/hopejr_right_arm_description.git
```

Build:
```shell
cd hopejr_right_arm
colcon build --symlink-install
. install/setup.bash
```

Run:
```shell
ros2 run hopejr_right_arm_description view_robot.launch.py
```