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
        FindPackageShare('hopejr_hand_description'),
        'rviz',
        'view_robot.rviz'
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
                        FindPackageShare('hopejr_hand_description'),
                        'urdf',
                        'hopejr_hand.xacro',
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

    ld.add_action(rviz_node)
    ld.add_action(rsp_node)
    ld.add_action(jsp_gui_node)

    return ld