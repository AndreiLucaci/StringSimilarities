#StringSimilarities
String similarities C# implementation

##Algorithms
Current implementation uses Levenshtein distance.
You can find more information about this [here](https://en.wikipedia.org/wiki/Levenshtein_distance)

##Tests - example
The tests cover basic behaviour

###Problem explanation
Given an instance of ```IStringSimiliarities``` one can compute the percentage representing the similarities between two given (input) strings

###Code example
```csharp

IStringSimilarities stringSimilarities = new LevenshteinStringSimilarities();

var firstInputString = "someString";
var secondInputString = "someOtherString";

var result = stringSimilarities.DetermineSimilarities(firstInputString, secondInputString);

// result should be a percentace, in our case 0.2% similar.

```

