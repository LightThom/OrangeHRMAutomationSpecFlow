Feature: UserManagement

@Admin @UserManagement
Scenario: I can access the UserManagement page
	Given I am logged in as an Admin
	When I navigate to the User Management screen
	Then the System Users search form is present
	And Search Results is present

Scenario: I can search for a user
	Given I am on the user management screen
	And I enter the Employee Name Carlos Lucas Zapata
	When I click Search
	Then the username is present


	@Admin @UserManagement @AddUser
Scenario: I can access the Add User page
	Given I am on the user management screen
	When I click Add
	Then the Add User form is present

		@Admin @UserManagement @AddUser
Scenario: I can add a user
	Given I am on the Add User form
	And I select the User Role Admin
	And I search for the employee name Anthony Nolan
	And I enter the user name Anthony Nolan5
	And I enter and confirm the password Password1
	When I click Save
	And I search for the username Anthony Nolan1
	Then the username is present with the Admin User Role