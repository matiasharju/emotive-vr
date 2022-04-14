# iMotions Vive Pro Eye integration v1.5

The *iMotions Vive Pro Eye integration* allows you to capture data from the Vive Pro Eye in iMotions and use real-time gaze data within an application. It was developed by Three Space Lab, Inc. and it takes the form of a Unity package for use alongside the *Vive SRanipal Eye SDK for Unity*.

## Version Log

2021-06-15: v1.5 Report all GazePoint fields with invariant culture  
2021-04-19: v1.4 Add support for pupil position on camera records  
2021-04-15: v1.3 Change Default Server Configuration  
2021-04-06: v1.2 Fix Eye Data Replay  
2021-03-25: v1.1 Support for Unity 2019.4/2020.3  
2019-08-14: v1.0 Initial release, Unity 2017.4  

Further details can be found in the [Changelog](#Changelog) at the end of this document.

## Overview

This document covers the following topics:

* Adding the *iMotions Vive Pro Eye integration* to a Unity project
* Understanding the behavior and output of the gaze data server
* Using realtime gaze data within an application

## Adding the integration to a project

### Prerequisites

If you have not previously used a Vive Pro Eye with your computer, follow the [official instructions](https://www.vive.com/eu/support/vive-pro-eye/category_howto/installing-eye-tracking-software.html) to install the Vive SRanipal eye tracking software. We suggest confirming that your eye tracking is fully functional before moving on to Unity.

The recommended Unity versions are 2019.4.x or 2020.3.x, which are the latest Unity LTS versions available at the time of writing. Other versions may work, but are not guaranteed to.

Before adding the integration plugin, first prepare your project by installing the SRanipal Eye SDK for Unity. This integration plugin was developed for use with version v1.3.2.0 of the SDK; please note that later versions of the SDK may include breaking changes. You can download the SDK at [this page](https://developer.vive.com/resources/knowledgebase/vive-sranipal-sdk/); after unzipping the SDK, locate the `Vive-SRanipal-Unity-Plugin.unitypackage` file and import it into your Unity project.

For integration with the SteamVR runtime, you have three options:

1. SteamVR Unity Plugin _(controller tracking + input through the SteamVR Input System)_
1. OpenVR Unity XR Plugin _(no controller tracking or button input)_
1. _[deprecated]_ Legacy XR

#### __Note on the SteamVR Unity Plugin__

The SteamVR Unity Plugin is not required to use the Vive Pro Eye with eye tracking and head tracking in Unity. However, you may want to add it to your project to allow the use of handheld controllers or Vive trackers.

If you would like to include the SteamVR plugin, you can import its unitypackage before or after importing ours.

We have included two additional prefabs that integrate version 2.7.3 of the SteamVR plugin. The `[ViveSR + iMotions + SteamVR (CameraRig)]` prefab uses the basic SteamVR CameraRig, which provides simple access to controller tracking. The `[ViveSR + iMotions + SteamVR (Player)]` prefab incorporates the Player from the SteamVR Interaction System, which allows the use of SteamVR's teleporting and hand interaction systems out-of-the-box.

Note that if you wish to use the SteamVR Interaction System, you will need to set up an Action Set under the new SteamVR Input System. Instructions for this can be found in the [SteamVR Plugin Documentation](https://valvesoftware.github.io/steamvr_unity_plugin/articles/Quickstart.html).

This package can also be used with the legacy SteamVR Plugin v1.2.3, but this is not recommended, as it relies on the OpenVR (desktop) package, which has been removed from the latest versions of Unity. There are no provided prefabs for this version of the plugin.

#### __Note on the OpenVR Unity XR Plugin__

Installing the SteamVR Unity Plugin will automatically install the [OpenVR Unity XR Plugin](https://github.com/ValveSoftware/unity-xr-plugin), which provides low-level integration with the SteamVR runtime for head tracking support. If you do not wish to use the SteamVR Unity Plugin, you will need to install this plugin manually. This can be done by downloading the [OpenVR Unity XR Plugin Installer](https://github.com/ValveSoftware/unity-xr-plugin/releases/tag/installer) zip package, which contains a `.unitypackage` file you can import into your project which will automatically install the latest version of the OpenVR Unity XR Plugin. 

If you choose this route, you will not have any controller tracking or input, as this plugin only provides head tracking to the Unity XR Management framework.

#### __Note on Legacy XR__

Unity's legacy XR input system has been deprecated in version 2019.x, and completely removed in version 2020.x and newer. If you are using 2019.x, you may still be able to use the legacy XR input for head tracking with this package. However, this is not recommended, and we do not officially support it. If you are upgrading a project that formerly used the Unity legacy XR input system, you are encouraged to switch to the state-of-the-art Unity XR Plugin Management framework.

### Steps for setting up your project

1. __(SteamVR Unity Plugin)__ Import the SteamVR Unity Plugin v2.7.x from the Unity Asset Store. It will guide you through setting up Unity XR and installing the OpenVR plugin. If you intend to use the Interaction System, you will also need to set up an Action Set. See [Note on the SteamVR Unity Plugin](<#Note on the SteamVR Unity Plugin>) above for details.
1. __(no SteamVR Unity Plugin)__ If you do not with to use the SteamVR Unity Plugin, you will still need to add the OpenVR Unity XR Plugin for head tracking through the SteamVR runtime. Using the Unity Package Manager (Window→Package Manager), add the "XR Plugin Management" package provided by Unity. Then download and import the [OpenVR Unity XR Plugin Installer](https://github.com/ValveSoftware/unity-xr-plugin/releases/tag/installer). See [Note on the OpenVR Unity XR Plugin](<#Note on the OpenVR Unity XR Plugin>) above for details.
1. Import the Vive SRanipal Eye SDK for Unity. See [Prerequisites](#Prerequisites) above for details.
1. Import the `iMotions-ViveProEye-integration.unitypackage` file into your project.
1. In your `Project` tab, navigate to the `3SL/ViveSRIntegration-Extras/Example` folder and open the `Example-iMotions-ViveSR` scene.
1. Press the play button and verify that everything is working as expected.

Your project should now be ready to go. If you have imported the SteamVR Unity Plugin, you may also want to open the `Example-iMotions-ViveSR-SteamVR` scene under `3SL/ViveSRIntegration-Extras/Example-SteamVR` for an example of teleportation.

You can use either example scene as a starting point. If you want to set up your own scene from scratch, you can do so with the following steps:

1. Create a new scene.
1. In your `Project` tab, navigate to the `3SL/ViveSRIntegration/Prefabs` folder. You should see the `[ViveSR + iMotions]` prefab.
1. Drag and drop the `[ViveSR + iMotions]` prefab into your scene.
1. Double-check that the `[ViveSR + iMotions]` object is at position (0,0,0), if desired, and that the default Unity `Main Camera` is disabled or deleted.

### Testing

You can press "play" at any time to start your Unity scene. You should see a message appear in the console stating that the TCP server is now listening for clients.

For convenience, we also provide a file of recorded gaze data that you can replay in place of real-time data. This can be useful for debugging your project without having to wear and calibrate the headset. If you would like to use this tool, follow these steps:

1. Find the `[ViveSR + iMotions]` object (or SteamVR variant) in your scene.
1. In the Hierarchy tab, select the `[ViveSR Gaze Data Replay]` object under `[ViveSR + iMotions]`.
1. Tick the checkbox in the Inspector tab to enable the `[ViveSR Gaze Data Replay]`.
1. If desired, check the `Play On Start` and/or `Loop` options on the `ViveSR Replayer` component.
1. Press "Play" to start your Unity scene. If you have selected `Play On Start`, recorded gaze data should immediately begin playing. Otherwise, press the toggle key (`P` by default) to start playing the data.

The replay system will function regardless of whether a Vive Pro Eye HMD is connected.

### Building

Simply follow the normal Unity steps to create a build of your project. The SRanipal SDK only provides DLLs for 64-bit Windows applications, so you must choose "x86_64" as the target architecture in the build settings (Edit→Build Settings→Architecture).

You should see a firewall prompt the first time you run a build that includes the gaze server. We recommend granting firewall permissions on both private and public networks. If these permissions are accidentally denied, we recommend starting *Windows Defender Firewall with Advanced Security* and modifying the `Inbound Rules`.

If you are unable to connect iMotions to your build, check the build's `output_log.txt` file ([see manual](https://docs.unity3d.com/Manual/LogFiles.html)) for socket exceptions. Note that the TCP server will not be able to start if its specified socket is already in use; this often happens when the Unity Editor has recently launched a server on the same port. If this issue occurs, try closing the Unity Editor, waiting for a short time, and reopening your build.

## Gaze data server

### Implementation of GazePoint

We implement a partial version of the [GazePoint API v2.0](www.gazept.com/dl/Gazepoint_API_v2.0.pdf) to broadcast gaze data in a format that iMotions can interpret.

Our server currently ignores configuration messages. It will maintain the same behavior regardless of any `<SET ... />` mesages sent by the client.

Each GazePoint record emitted by our server begins with `<REC ` and ends with `.>\r\n`. These messages are sent as ASCII-encoded strings.

#### Timing

Each GazePoint record has a counter attribute, `CNT`, which is intended to inform the client in the event that records are missing or out-of-order. We initialize a counter at zero when the server is started and increment it every time a gaze data point is passed to the server. This increment is applied regardless of whether the data point is valid or any clients are connected.

The GazePoint API specifies a `TIME` attribute denominated in seconds; however, iMotions expects this attribute to instead be denominated in milliseconds. The SRanipal plugin emits data points with a `timestamp` field, which is a 32-bit integer in milliseconds. Our software records the `timestamp` of the first data point as our `firstTimestamp`. In converting each data point to GazePoint format, we subtract the `firstTimestamp` from that record's `timestamp`; we later write this value as a string with seven significant digits.

#### Point of Gaze

GazePoint uses fractional screen coordinates for point-of-gaze information. We compute point-of-gaze for each eye with reference to a first-person screen camera in order to populate the following attributes:

* Left eye PoG (`LPOGX`, `LPOGY`, `LPOGV`)
* Right eye PoG (`RPOGX`, `RPOGY`, `RPOGV`)
* "Best" eye PoG (`BPOGX`, `BPOGY`, `BPOGV`), based on the `VerboseData.combined` object

Note that the GazePoint y-coordinate increases from top to bottom of the screen, whereas Unity screen coordinates increase from bottom to top. We correct this by taking `y = 1-y` when converting between formats.

The first-person screen camera is represented in your Unity scene by a `PointOfViewMapper` component, such as the one attached to the provided `Screen Camera` under the `[ViveSR + iMotions]` prefab. The Unity camera on the `Screen Camera` object defaults to a 60 degree vertical field of view, which is somewhat larger than the field of view of the Vive Pro HMD and may not be vertically centered. Feel free to adjust the FoV or orientation of this camera if you would like a tighter fit around your users' actual field of view.

If your application is not running in borderless fullscreen mode, there will be a discrepancy between the reported point-of-gaze coordinates and the position of visual elements in a screen-capture video. To prevent this issue, our example scenes and prefabs include an *EnableFullScreen* script which forces Unity to run in borderless fullscreen at maximum resolution.

In order to compute screen-space point-of-gaze for each eye, we first compute 3D point-of-gaze and then project the 3D coordinates into camera space. This requires us to choose a point in 3D space along each eye gaze vector. The `PointOfViewMapper` exposes an `assumedEyeFocusDistance` field, in meters relative to the user, to use as a default per-eye focus distance. Furthermore, if the `useMeasuredFocusDistance` flag is enabled, the `PointOfViewMapper` will use the combined `ConvergenceDistance` reported by the SRanipal plugin to infer dynamic per-eye distances when that `ConvergenceDistance` is available, falling back to `assumedEyeFocusDistance` otherwise. 

#### Attributes containing partial dummy data

* "Left Eye 3D Data" attributes (`LEYEX`, `LEYEY`, `LEYEZ`, `LPUPILD`, `LPUPILV`)
* "Right Eye 3D Data" attributes  (`REYEX`, `REYEY`, `REYEZ`, `RPUPILD`, `RPUPILV`)
  * The pupil dilation attributes, `LPUPILD` and `RPUPILD`, are denominated in meters. The SRanipal plugin reports pupil diameter in millimeters, so we convert these values to meters and pass them along.
  * The pupil validity records (`LPUPILV`, `RPUPILV`) will be `1` if and only if the corresponding pupil diameter records (`LPUPILD`, `RPUPILD`) contain valid values.
  * The positional data provided here is relative to a camera focal point; the SRanipal plugin does not provide this information, so we use dummy data.
* "Left Eye Pupil" attributes (`LPCX`, `LPCY`, `LPD`, `LPS`, `LPV`)
* "Right Eye Pupil" attributes (`RPCX`, `RPCY`, `RPD`, `RPS`, `RPV`)
  * The pupil-position-on-camera records (`LPCX`, `LPCY`, `RPCX`, `RPCY`) contain live data.
  * The pupil-position-valid records (`LPV`, `RPV`) are live and will be `1` if and only if the values in the corresponding pupil-position-on-camera records are valid.
  * The pupil diameter records (`LPD`, `RPD`) are expected in pixels, which we cannot derive from the SRanipal SDK, so we provide dummy values.
  * The pupil scale factor records (`LPS`, `RPS`) are also not provided by the SRanipal SDK, so we provide fixed dummy values.

#### Omitted attributes

The following attributes are not included in the XML emitted by our server:

* "Time Tick" (`TIME_TICK`)
  * This is the CPU time tick at capture time, which is not provided by the SRanipal plugin.
* "Fixation POG" attributes (`FPOGX`, `FPOGY`, `FPOGD`, `FPOGID`, `FPOGV`)
  * This would require some fixation filter to be implemented within each supporting program. It is also not especially meaningful given a 6DoF viewpoint in a 3D environment.
* "Cursor position" attributes (`CX`, `CY`, `CS`)
  * While easily added, the position of the cursor is generally not relevant for use with an HMD.
* "User data" (`USER`)
  * This is custom user-provided data.

### Network Scenarios

This package is compatible with a range of network scenarios. Details for the two most common scenarios are given below.

In any of the prefabs this package supplies (e.g. `[ViveSR + iMotions + SteamVR2 (Player)]`), the Gaze Point Server local IP and port can be configured under the GameObject named `[Monitor and Server]` on a component called `Gaze Point Server Manager`.

#### Local Machine (default)

If you are running the iMotions software on the same machine as your application using the iMotions Vive Pro Eye integration, the default settings should be adequate. The server defaults to listening for connections on local IPv4 address `127.0.0.1` on port `4050`, which the iMotions software should already by configured to connect to.

#### Local Area Network (LAN)

If you wish to run the iMotions software on a different machine on the same local network as your application using the iMotions Vive Pro Eye integration, some configuration is required.

In this case, the default server IP address should be changed from `127.0.0.1` to some other address, e.g. `0.0.0.0`, the machine's LAN IPv4 address, or some DNS name for the machine. This can be done in the Unity Editor for your application in the `Local Address` field on the `Gaze Point Server Manager` component mentioned above.

Additionally, some care is required with regard to Windows firewall settings. There must be some Inbound firewall rule that allows your application to receive TCP connections from the local network on the port configured in the `Gaze Point Server Manager` (`4050` by default). More information on configuring inbound firewall rules can be found [here](https://docs.microsoft.com/en-us/windows/security/threat-protection/windows-firewall/create-an-inbound-port-rule).

## Using gaze data for application features

This section will provide a brief overview of how the *iMotions Vive Pro Eye integration* handles gaze data, how this differs from the behavior of the underlying *Vive SRanipal Eye SDK for Unity*, and how developers using our integration should retrieve gaze data for real-time use within an application.

### Characteristics of the Vive SRanipal Eye SDK

The SRanipal API provides one core method for acquiring gaze data:

```{csharp}
[DllImport("SRanipal")] public static extern Error GetEyeData(ref EyeData_v2 data);
```

Polling this method is our technique for fetching gaze data. This API function is **not thread-safe**--calling the method from two threads at roughly the same time will freeze the host process.

The latest SRanipal API provides additional features that we do not support and may only be used at your own risk. The SRanipal Eye API can be configured through settings on the singleton `SRanipal_Eye_Framework` Component, which in our prefabs is attached to the `[Monitor and Server]` GameObject. For our application to work, "Enable Eye" must be **enabled**, "Enable Eye Data Callback" should be **disabled**, and "Enable Eye Version" must be **Version 2**.

### Our gaze API: ViveSRGazeMonitor

To provide an event-oriented basis for eye-tracking applications, we provide a singleton component class: `ViveSRGazeMonitor`. `ViveSRGazeMonitor` acts as a layer on top of the SRanipal plugin that polls `SRanipal_Eye_API.GetEyeData` and re-emits `EyeData_v2` objects for any number of consumers.

Furthermore, `ViveSRGazeMonitor` supports the injection of synthetic or recorded gaze data points in place of realtime data from the SRanipal plugin. This allows a developer to create and test gaze-based features without having to wear and calibrate the headset.

An instance of `ViveSRGazeMonitor` comes attached to the `[ViveSR + iMotions]` prefab. Referencing the `ViveSRGazeMonitor.Instance` property will create a new `ViveSRGazeMonitor` if none already exists.

#### Sample polling strategy

`ViveSRGazeMonitor` can be configured to poll `GetEyeData_v2` in one of three ways:

* On a dedicated thread
* On the main Unity thread during the Update cycle
* On the main Unity thread during the FixedUpdate cycle

The default and recommended option is to use the dedicated thread. The polling strategy can be changed by editing the `ViveSRGazeMonitor` instancce in your scene.

__Dedicated Thread__ : The dedicated thread will capture gaze data at the full 120Hz, with occasional dropped samples. It will maintain this sampling rate independent of the performance of your Unity scene, and has a negligible impact on performance itself. The downside is that, as mentioned above, only one thread can call `GetEyeData_v2` at a time without freezing the Unity process; therefore, every part of your application that consumes gaze data **must** receive it from the `ViveSRGazeMonitor` through either the `LatestEyeData` property or the `OnEyeData` event. 

This technique also implies a particular way of interacting with the SRanipal SDK. Each API method in `SRanpial_Eye` has an overload that takes an `EyeData_v2` struct as an argument, and one that does not. For example, compare the following:
```C#
public static bool GetGazeRay(GazeIndex gazeIndex, out Vector3 origin, out Vector3 direction, EyeData_v2 eye_data);
public static bool GetGazeRay(GazeIndex gazeIndex, out Vector3 origin, out Vector3 direction)

```
The former operates directly on the `EyeData_v2` struct you pass without querying the underlying API, while the latter calls `GetEyeData_v2` internally. If you are using a dedicated background thread for eye data updates, you **must** use the versions of any API functions which take the `EyeData_v2` struct, passing them the `EyeData_v2` struct you got from our `ViveSRGazeMonitor` (either the `LatestEyeData` property or from the `OnEyeData` event). This requirement also means that the examples from the SRanipal API are not compatible with this polling scheme and attempting to use them directly will freeze your app.

__Unity Update__: Polling on the Unity Update cycle will capture at most one gaze data sample per graphics frame. This means that at most 90Hz will be captured while using the Vive Pro Eye. Furthermore, if the frame rate is reduced (for example, in a graphically intensive scene) then the sample frequency will be reduced proportionally.

__Unity FixedUpdate__: Polling on the FixedUpdate cycle will capture at most one gaze data sample per Unity physics tick. By default, this cycle runs at 50Hz. It can be configured to run at higher frequency based on a project setting (`Edit > Project Settings > Time > Fixed Timestep`). Setting `Fixed Timestep` to around 0.005 (200Hz) will capture about 120Hz of gaze data. However, this will also have a serious impact on the performance of your application, since other code (such as the physics system) will also be running more frequently.

## Changelog

### Version v1.5 (2021-06-15)

- Add `CultureInfo.InvariantCulture` to all calls to `float.ToString(IFormatProvider)` in the XML providers.

### Version v1.4 (2021-04-19)
- Change from `EyeData` struct to `EyeData_v2` struct
- Gaze Point API changes:
  - Change LPCX, LPCY, RPCX, RPCY records from dummy to live based on `SingleEyeData.pupil_position_in_sensor_area` 
  - Change LPV, RPV records from dummy to live based on `SingleEyeData.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_PUPIL_POSITION_IN_SENSOR_AREA_VALIDITY)`
  - Change LPUPILV, RPUPILV from dummy to live based on `SingleEyeData.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_PUPIL_DIAMETER_VALIDITY)`

### Version v1.3 (2021-04-15)
- Change default gaze data server IP from `0.0.0.0` to `127.0.0.1`
- Add [Network Scenarios](#network-scenarios) section to README.

### Version v1.2 (2021-04-06)
- Fix eye data replay
- Update README to include x86_64 target architecture requirement.

### Version v1.1 (2021-03-25)
This version brings our integration up-to-date with the latest (at the time of writing) LTS releases of Unity, as well as updating to support Unity and SteamVR's modern standards for XR tracking and input.
- Update Unity support 2017.4 → 2019.4/2020.3
- Upgrade target Vive SRanpial SDK version v1.0.1.0 → v1.3.2.0
- Upgrade target SteamVR integration version v1.2.3 → v2.7.3
- Use Unity XR Management framework instead of legacy XR for default example prefab.
- Reduce garbage pressure of GazePoint logging.
- Update README