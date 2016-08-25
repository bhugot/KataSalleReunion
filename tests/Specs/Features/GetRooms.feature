Feature: GetRooms
	In order to book a meeting room
	As Julien
	I want to be able to list the rooms

Scenario: List all rooms
	Given I have all the following rooms:
	| Name  |
	| room0 |
	| room1 |
	| room2 |
	| room3 |
	| room4 |
	| room5 |
	| room6 |
	| room7 |
	| room8 |
	| room9 |

	When I Ask for rooms
	Then I would get the following rooms
	| Name  |
	| room0 |
	| room1 |
	| room2 |
	| room3 |
	| room4 |
	| room5 |
	| room6 |
	| room7 |
	| room8 |
	| room9 |