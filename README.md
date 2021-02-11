# Coffee Date

At Urban Timetravel, we like to get together on Friday and have coffee in pairs to catch up. This app helps pair up people who want to participate.

The repository contains a multiplatform app template of Xamarin.Forms

## Setup

To get the project up and running on your development machine, just clone the repository

`git clone https://github.com/urbantimetravel/XamarinCoffeedate.git`

## XamarinCoffeeDate

To open the Xamarin solution, click the `CoffeeDate.sln` solution file in the root folder of the project.

The Xamarin.Forms project currently contains
- `CoffeeDate` the Xamarin.Forms main project which is the entry point for your app
- `CoffeeDate.iOS` the iOS project files needed to build an iOS app
- `CoffeeDate.Android` the Android-specific files needed to build an Android app

### iOS

To launch the iOS app in the simulator or on a device, use the regular `Run` routine within Visual Studio.
To build an archive for the app store or ad hoc distribution, right click on `CoffeeDate.iOS` and select `Archive for publishing`

### Android

To run the Android project, use the regular `Run` routine within Visual studio. You can use both the simulator and your Android device. 
To build an *.apk for distribution, right click on `CoffeeDate.Android` and select `Archive for publishing`

## Future Work

- Login via Microsoft Account to check in 
- Push notifications at set date
