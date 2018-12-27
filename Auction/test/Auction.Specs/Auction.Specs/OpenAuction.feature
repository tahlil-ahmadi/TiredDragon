Feature: OpenAuction
	In order to sell my product with the best price
	as a seller
	I want to be able to open an auction 

Scenario: Opening an auction successfully
	Given I have a confirmed account
	And I have entered the following information for auction
	| Title | StartingPrice | EndDate    |
	| X     | 1000          | 2020-01-01 |
	When I open the auction
	Then I should be able to see my auction in the list of open auctions