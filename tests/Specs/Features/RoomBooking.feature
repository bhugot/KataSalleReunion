Feature: Room booking
	In order to have a room for my meeting
	As Julien
	I want to be able book a room

Background: 
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

Scenario: Book room when not used
	Given their is no previous registration
	When I book the room room1 as Julien for the 08/26/2013 from 2pm to 4pm
	Then the result should be ok
Scenario: Book room when other hour already booked
	Given their is previous registrations:
	| room  | user   | date       | start | end |
	| room1 | Julien | 08/26/2013 | 2pm   | 4pm |
	| room1 | Julien | 08/26/2013 | 6pm   | 7pm |
	When I book the room room1 as Julien for the 08/26/2013 from 5pm to 6pm
	Then the result should be ok


Scenario: Unbook room
	Given their is previous registrations:
	| room  | user   | date       | start | end |
	| room1 | Julien | 08/26/2013 | 2pm   | 4pm |
	When I unbook the room room1 as Julien for the 08/26/2013 at 2pm
	Then the result should be ok

Scenario: Book room already used should return the empty slots
	Given their is previous registrations:
	| room  | user   | date       | start | end |
	| room1 | Kevin  | 08/26/2013 | 2am   | 12am |
	| room1 | Kevin  | 08/26/2013 | 2pm   | 4pm |
	| room1 | Julien | 08/26/2013 | 6pm   | 7pm |
	When I book the room room1 as Julien for the 08/26/2013 from 2pm to 3pm
	Then the result should be a conflict
	And the responses should contains following slots:
	| start | end  |
	| 0am   | 1am  |
	| 1am   | 2am  |
	| 12am  | 1pm  |
	| 1pm   | 2pm  |
	| 4pm   | 5pm  |
	| 5pm   | 6pm  |
	| 7pm   | 8pm  |
	| 8pm   | 9pm  |
	| 9pm   | 10pm |
	| 10pm  | 11pm |
	| 11pm  | 12pm |


Scenario: Book room already used should return the empty slots another case
	Given their is previous registrations:
	| room  | user   | date       | start | end |
	| room1 | Kevin  | 08/26/2013 | 0am   | 12am |
	| room1 | Kevin  | 08/26/2013 | 2pm   | 4pm |
	| room1 | Julien | 08/26/2013 | 6pm   | 12pm |
	When I book the room room1 as Julien for the 08/26/2013 from 2pm to 3pm
	Then the result should be a conflict
	And the responses should contains following slots:
	| start | end  |
	| 12am  | 1pm  |
	| 1pm   | 2pm  |
	| 4pm   | 5pm  |
	| 5pm   | 6pm  |
	