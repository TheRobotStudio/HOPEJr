# hopejr_arm_description

## Usage
Create a new workspace and clone this library:
```shell
mkdir hopejr_arm
cd hopejr_arm
mkdir src
cd src
git clone https://github.com/song-jisu/hopejr_arm_description.git
```

Build:
```shell
cd hopejr_arm
colcon build --symlink-install
. install/setup.bash
```

Run:
```shell
ros2 run hopejr_arm_description view_robot.launch.py
```