Feature: Twitter
	Simple calculator for adding two numbers

@login
Scenario: Login to Twitter
	Given User Navigates to  https://twitter.com/
	Then Clicks on the Login button on LandingPage
	Then User inputs the UserName Behrang28986287
	And User inputs the Password automationtesting
	And Clicks on the Login botton on LoginPage

@Tweet
	Scenario:  User Can Tweet
	Given User is Loged in to  https://twitter.com/ With Behrang28986287 and automationtesting
	Then User Can send a text tweet of Testing automatic Tweet


@initialphoto
	Scenario:  User Can Edit profile picture
	Given User is Loged in to  https://twitter.com/ With Behrang28986287 and automationtesting
	#Then User Changes the profile Picture
	Then user Edits the profile picture