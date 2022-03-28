## [0.3.3-preivew.1] - 2022-03-28
- Changed dependency Entities to version 0.50.0-preview.24
- Removed dependency DOTS editor.

## [0.3.2-preivew.1] - 2021-02-09
- Change dependency Entities to version 0.17.0-preview.42
- Change dependency DOTS editor version 0.12.0-preview.6

## [0.3.1-preivew.1] - 2021-01-07
- Update to support DSC-Core and DSC-Input update.

## [0.3.0-preivew.1] - 2020-11-11
- Add StandardTemplate sample.
- Change minimum requirement Unity version to 2020.2
- Change dependency Entities to version 0.16.0-preview.21
- Change dependency DOTS editor version 0.11.0-preview.3
- DSC_ADD_PlayerAuthor now will automatic get component DSC_Actor_Player from parent if it's null.

## [0.2.5-preivew.1] - 2020-09-05
- Move all physic system to run in FixedStepSimulationSystemGroup.
- Add DSC_ADS_JumpInput.
- Add DSC_ADG_FixedUpdate_Early.
- Add DSC_ADG_FixedUpdate_Normal.
- Add DSC_ADG_FixedUpdate_Late.
- Remove DSC_ADG_Update_PreEarly.
- Remove DSC_ADG_Update_PostEarly.
- Remove DSC_ADG_Update_PreNormal.
- Remove DSC_ADG_Update_PostNormal.
- Remove DSC_ADG_Update_PreLate.
- Remove DSC_ADG_Update_PostLate.

## [0.2.4-preivew.1] - 2020-09-01
- Add DSC_ADG_Update_PostEarly.
- Add DSC_ADG_Update_PreNormal.
- Add DSC_ADG_Update_PostNormal.
- Add DSC_ADG_Update_PreLate.
- Add DSC_ADG_Update_PostLate.

## [0.2.3-preivew.1] - 2020-08-31
- Add DSC_ADG_Update_PreEarly.
- Add DSC_ADG_Update_Early.
- Add DSC_ADG_Update_Normal.
- Add DSC_ADG_Update_Late.

## [0.2.2-preivew.1] - 2020-08-24
- Change dependency Entities to version 0.14.0-preview18
- Add dependency DOTS editor version 0.10.0-preview

## [0.2.1-preivew.1] - 2020-08-14
- Improved MathUltility EulerAngle API convert correctly.

## [0.2.0-preivew.1] - 2020-07-28
- Change minimum requirement Unity version to 2020.1
- Change dependency Entities to version 0.13.0-preview24

## [0.1.4-preivew.1] - 2020-07-27
- Add support for Character Controller.
- Now FPS Rigidbody is broken.

## [0.1.3-preivew.1] - 2020-07-08
- Add gravity component and system.

## [0.1.2-preivew.1] - 2020-07-07
- Fixed bug player stuck in jumping state forever if jump never leave player from ground.
- Added FPS Template sample.

## [0.1.1-preivew.1] - 2020-07-06
- Now MoveSlopeCheck and StickToGround system use Actor transform to calculate direction instead.

## [0.1.0-preivew.1] - 2020-07-05
- Change minimum requirement Unity version to 2019.4
- Add StickToGround component and system.
- Fixed DSC_ADS_DestroyNullGameObject generate garbage every frame.

## [0.0.7-preivew.2] - 2020-07-04
- Add MoveSlope component and system.
- Add Unity Entities dependencies.

## [0.0.6-preivew.2] - 2020-07-02
- Move DSC_Actor_Input to DSC-Input package. (Rename script to DSC_Input_Player.)
- Remove Unity Input dependencies.

## [0.0.5-preivew.1] - 2020-07-01
- Move Input template sample to DSC-Input package instead.

## [0.0.4-preivew.1] - 2020-06-08
- Remove all of component and system about Entity to GameObject.
- Add MoveSpeed3D component.
- Add LockCursor component and system.
- Add GroundCheck component and system.
- Add GroundDrag component and system.
- Add Jump component and system.
- Add FPS move system.
- Add FPS Rotate system.

## [0.0.3-preivew.1] - 2019-05-31
- Add InputTemplate sample.
- Change DSC_ADS_Input to use new GetAxisEvent API from DSC_Input instead GetHorizontal and GetVertical.

## [0.0.2-preivew.1] - 2019-05-29
- Add Input data and system.
- Add DSC_ADD_Player component for store player data.
- Add DSC_Actor_Input for use with new input system.
- Add DSC_Actor_Player.

## [0.0.1-preivew.1] - 2019-05-21
- Add components tag GameObjectToEntity and EntityToGameObject.
- Add MoveEntity system.
- Combine tag CopyPositionTransform and CopyPositionTraslation to tag CopyPosition.
- Combine tag CopyPositionGameObject and CopyPositionEntity to tag CopyRotation.
- Change CopyMoveType component name to MoveGameObjectType.
- Change CopyMove system name to MoveGameObject.

## [0.0.0-preivew.1] - 2019-05-18
- Add component and system for copy position and rotation between GameObject and Entity;.
- Add Move component and system.