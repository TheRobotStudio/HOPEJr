# HOPEJr
HOPEJr is an open-source DIY Humanoid Robot with dexterous hands.

<div align="center">
  <img src="Artwork/hopejr.png" alt="HOPEJr Arm" />
</div>

As of 26/06/2025 the most up to date releases reflect the work of Martino Russi at Hugging Face. 
The repo now includes a teleoperation kit which builds on top of [Project Homunculus](https://github.com/nepyope/Project-Homunculus). STL for both can be found in 3dprint files/STL. STEP/arm.step and STEP/exoskeleton.step are the updated step files. PCBs are used to connect motors together and greatly simplify the assembly of the teleop exoskeleton.

# Improvements 

## Fingers
Fingers now have an additional, underactuated dof at the DIP joint. This allows the hand to adapt to the object being gripped. The build has been simplified, requiring much less physical strength. I addressed the core issue with rolling contact joints (subsceptibility to sheer and twist) by locking the wires into place using screws, using thicker fishing wire. I use 3d printer filament PTFE tubes to drive the tendons, simpler.
The thumb is now opposable: y approach for doing so was essentially modeling an actuated version of the thumb tracker i developed previously.
Spools were added to linearize the movement of the fingers relative to motor angle, allowing for faster action and 1:1 teleop

## Arm
Tolerances were relaxed slightly, and all threaded inserts were replaced with bolts. Including the PCBs this means that no soldering is required for the assembly. Wires can now pass behind the mantle, and the passive tendon has been removed, with the arm using a bulkier STS8215 to handle the extra load. 

## Exoskeleton
This teleop device has been developed specifically for HopeJr: each joint of the robot has a dual in the exoskeleton, including the hand. To measure angles we use diametric hall encoders, one for each joint of the hand and two for arm joints, allowing for more accurate tracking. This device is also fully assemblable without soldering, thanks to the custom PCBs that were developed at HF

## Software
All the above has been integrated with LeRobot, meaning it's now possible to record, train and do inference on HopeJr. 

---

> I want to foster a community that changes the world.
> 
> In a literal sense, the widespread adoption of robots is exactly that: the power to change the physical world with digital systems.
> 
> Open source has a crucial role to play in the development of this technology only if the tools are available to make that a practical reality for "the masses".
> 
> Open source software would clearly be a nonsense if they weren't billions of devices readily available for coding.
> 
> To this end, lowering cost whilst maintaining an adequate level of functionality is the highest design constraint.
> 
> The intention is to lever the tremendous performance increases that AI software offers to offset the significant differences in low cost hardware.
> 
> This is the great promise that needs testing: can AI genuinely control much lower cost hardware and finally produce the robots that we've all been dreaming of?
> 
> 3d printed plastic robots offer tremendous precision but significantly lower stiffness, a trait that is true in fact of all the lower cost versions of components in a robot. Here there may be a happy coincidence because the problem with expensive hardware is that it cannot be safely used around people. Industrial robots are made of metal and remarkably stiff gearboxes to produce rapid, highly precise movements - like a robot.
> 
> But people don't move that way, we are bouncy and capable of feats of strength and precision that far outperform an industrial machine of similar weight and power.
> 
> So, we know it's possible to learn how to control a bouncy system and we know they're lower cost.
> 
> All that's missing are the plans and instructions to build a DIY population of humanoid robots.

<div align="right"><em>- Rob Knight</em></div>

HOPEJr Community links:

WhatsApp: https://chat.whatsapp.com/HumZyAUoPps9EW8TwcGFkC

Discord: https://discord.gg/yPpf327PWF
