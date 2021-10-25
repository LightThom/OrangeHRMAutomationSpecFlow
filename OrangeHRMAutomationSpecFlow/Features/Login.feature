Feature: Login

@Login
Scenario: I can log in
	Given I navigate to the to OrangeHRM app
	When I attempt to login with Admin credentials
	Then I am logged in