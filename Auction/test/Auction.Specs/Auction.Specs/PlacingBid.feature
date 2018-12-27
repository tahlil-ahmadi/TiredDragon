Feature: Placing Bid
	In order to win an auction 
	as a bidder
	I should be able to place my bid on an auction

Background: 
	Given David has an open auction with followin information
	| Title                  | EndDateTime      | StartingPrice |
	| Jackson King V KVXMG X | 2020-01-01 20:00 | 1000          |

Scenario: Place a first bid successfully 
	When I place my bid with '1100' amount
	Then I should be set as current winner

Scenario: Place on a bid on winning bid successfully
	Given Sarah is current winner with '1100' amount
	When I place my bid with '1200' amount
	Then I should be set as current winner

Scenario Outline: Place first bid with invalid price
	When I place my bid with <amount> amount
	| Amount |
	| 900    |
	| 1000   |
	Then I should be given an error that my bid has invalid amount

Scenario Outline: Place a bid with invalid price on winning bid
	Given Sarah is current winner with '1100' amount
	When I place my bid with <amount> amount
	| Amount |
	| 900    |
	| 1000   |
	| 1100   |
	Then I should be given an error that my bid has invalid amount
