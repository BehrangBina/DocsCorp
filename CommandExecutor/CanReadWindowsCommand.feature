Feature: CanReadWindowsCommand
	Simple calculator for adding two numbers

@CMD
Scenario: Can Run Tests with Environement Variable
	Given  user-command is configured in Environment variable
	Then can echo temp message