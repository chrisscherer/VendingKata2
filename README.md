# VendingKata2
A second pass at the vending machine kata


Thoughts:


I’m trying to write tests how I was originally taught, writing as little code as possible to get the green light and then refactoring if necessary. The problem I’m running into is mainly with trying not to over architect. I know the vending machine will need different kinds of coins, and not just validate input based on a single incoming integer. Is the proper TDD way to keep developing with the setup I know is wrong and won’t be used until I hit a use case that requires it? In the case of Katas this is a little less clear as there isn’t much of a feature roadmap or what the customer wants done first, so It’s a question of when I consider the first user story about accepting coins done. Is this a problem with katas having no real definition of done, or am I just confused?

Another thing I don’t quite get is how to test ranges. The only accepted coins are nickels, dimes, and quarters. Does that mean I should do a test to make sure each one is valid input? What tests need to be done to demonstrate proper validation, like if the coin size and dimensions are wrong. There’s such a wide range of invalid input that you’d either need to accept the premise that your method is going to do the right thing or test edge cases and valid inputs or something.

Is it worth grouping tests that have the same preconditions together for ease of reading and cutting down on some repeated precondition setup? The example I’m looking at is all the tests that use a 5x5 coin.