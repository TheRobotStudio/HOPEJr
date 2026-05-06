import os
from os import environ

from launch import LaunchDescription
from launch.actions import DeclareLaunchArgument, Shutdown
from launch.substitutions import PathJoinSubstitution, Command, LaunchConfiguration
from launch_ros.substitutions import FindPackageShare
from launch_ros.actions import Node

def generate_launch_description():
    ld = LaunchDescription()

    environ['QT_AUTO_SCREEN_SCALE_FACTOR'] = '0'
    rviz_config_file = PathJoinSubstitution([
        FindPackageShare('hopejr_arm_description'),
        'rviz',
        'view_robot.rviz'
        # 안해도 오류는 없는데, 저장된 설정을 가져옵니다. 이런 느낌이다.
    ])

    rviz_node = Node(
        package='rviz2',
        executable='rviz2',
        name='rviz2',
        output='screen',
        arguments=['-d', rviz_config_file],
        on_exit=Shutdown()
    )

    rsp_node = Node(
    # sudo apt install ros-humble-robot-state-publisher라는 패키지
    # 반드시 있어야하며, urdf를 입력받아야한다.
        package='robot_state_publisher',
        executable='robot_state_publisher',
        name='robot_state_publisher',
        output='screen',
        parameters=[{
            'ignore_timestamp': False,
            'robot_description':
                Command([
                    'xacro ',
                    PathJoinSubstitution([
                        FindPackageShare('hopejr_arm_description'),
                        'urdf',
                        'hopejr_arm.urdf.xacro',
                    ]),
                ]),
        }]
    )

    jsp_gui_node = Node(
        package='joint_state_publisher_gui',
        executable='joint_state_publisher_gui',
        name='joint_state_publisher',
        output='screen'
    )

	#rviz에서 urdf를 보고 싶으니 추가를 한다고 이해
    ld.add_action(rviz_node)
    ld.add_action(rsp_node)
    ld.add_action(jsp_gui_node)

    return ld