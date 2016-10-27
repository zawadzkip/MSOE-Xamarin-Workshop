# MSOE Xamarin Workshop

- [Install Docs](#install)
  - [Mac Install](#mac)
  - [Windows Install](#windows)
  - [Xamarin Android Player](#xamarinandroidplayer)
  - [Finalizing Install](#finalizing)

## Install
<br><b>Windows and Mac Only<br>

Go to [Xamarin Downloads](https://www.xamarin.com/download) and make your setup information.
It should look similar to this. This is what it looks like for a macOS user.
![setup image](http://image.prntscr.com/image/0757d183eeb443ec915003761ddf6291.png)
Once you have started this download, go ahead and move into your OS specific install instructions.

### Windows
Minimum OS: Windows 7
- Start your install, and it should start with a screen similar to this. ![windows](https://developer.xamarin.com/guides/android/getting_started/installation/windows/Images/installer-community.png)
- **Make sure you Accept Xamarin when you are prompted** as well as an licensing they mention.
- ![stuff](https://developer.xamarin.com/guides/android/getting_started/installation/windows/Images/installer3.png)
![android](https://developer.xamarin.com/guides/android/getting_started/installation/windows/Images/installer4.png)Go ahead and install the Android SDK if you don't have it already, otherwise you can point Xamarin and the installer to where you have it installed currently. Your download/install will now begin.
- Once you are all done getting Android installed, go to **Tools -> Options -> Xamarin -> Android Settings** and make sure your directories are all set correctly. You will have android build issues otherwise. If you downloaded Android through this installer, this should all be good for you. ![android build](https://developer.xamarin.com/guides/android/getting_started/installation/windows/Images/vs-options.png)


### Mac
Minimum OS: Mac OSX Yosemite (10.10)
- Go to the app store and download [XCode](https://itunes.apple.com/us/app/xcode/id497799835?mt=12) Once Xcode is installed and downloaded. Open it once to confirm, and accept and licenses it gives you. You will need to accept XCode licenses in the future whenever it is updated, otherwise you may not be able to Debug or build your iOS app.
- Make sure XCode is installed and ready to go before Xamarin Studio.
- Once XCode is installed, go ahead and start your Xamarin Studio install, accept all the licensing and continue until you reach this screen. ![setups steps](https://developer.xamarin.com/guides/android/getting_started/installation/mac/Images/productSelection.png)
- **Make Sure Android and iOS are installed. We need these for Xamarin.Forms**
- Now the install will show you basic overview information for setup, and what will be installed. ![overview](https://developer.xamarin.com/guides/android/getting_started/installation/mac/Images/prerequisitesNew.png)
- This is the part that takes a while **You will need to enter your user password a couple of times in order to complete installation**![long part](https://developer.xamarin.com/guides/android/getting_started/installation/mac/Images/installProcess.png)
- Congrats! You're done. ![complete](https://developer.xamarin.com/guides/android/getting_started/installation/mac/Images/installationComplete.png)

### Xamarin Android Player
I would recommend using [Xamarin Android player](https://developer.xamarin.com/releases/android/android-player/) for Android emulators. The emulators Xamarin has are faster than the default emulators and link up to Xamarin Studio/Visual Studio nicely. Otherwise you can debug and run your app using an Android device. If you download XAP, go ahead and download one of the devices (like the ones below) that you would like to test on. ![XAP Mac](http://image.prntscr.com/image/d637fc3ccd524227a18ebc347dd36b24.png)

### Finalizing
Now after you have installed everything, open either Visual Studio or Xamarin Studio, and create an empty Xamarin.Forms solution. Here's what it looks like in Xamarin Studio.
![New Solution](http://image.prntscr.com/image/6a3fe380575b4cf181505b93783e8bda.png)
<br>
#### Select Forms App
![Forms](http://image.prntscr.com/image/2f337fdfb2c94cdabea4296cd4a9340f.png)
<br>
#### Name your solution
![Test Solution](http://image.prntscr.com/image/bd19672fdd554de78a1474a3c6d76d8d.png)
#### Create your Solution
![Create](http://image.prntscr.com/image/0bcbf276947949bfae1ece8d01ddcb66.png)
#### Run
![Run](http://image.prntscr.com/image/09f7e541a34044d3bf400763ec4256bf.png)
Right click on the .Droid project and select "Set as startup project", then as long as you have an Android device connected or a Xamarin Android Player emulator installed, you will be able to run your project. Go ahead and do that, if you build and an app pops up. *Congrats! You're ready to code!*
