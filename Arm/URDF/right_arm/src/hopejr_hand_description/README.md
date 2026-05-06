# hopejr_hand_description

This library is basically created for addition to other robot libraries.
## Usage
Create a new workspace and clone this library:
```shell
mkdir hopejr_hand
cd hopejr_hand
mkdir src
cd src
git clone https://github.com/song-jisu/hopejr_hand_description.git
```

Build:
```shell
cd hopejr_hand
colcon build --symlink-install
. install/setup.bash
```

Run:
```shell
ros2 run hopejr_hand_description view_robot.launch.py
```