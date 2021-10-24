Feature: Login

@Login
Scenario: I can log in
	Given I navigate to the to OrangeHRM app
	When I enter the user name
	And I enter the password
	And I click Login
	Then I am logged in