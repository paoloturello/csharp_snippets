# csharp_snippets
> Random chunks of significative C# code

## SteinhausJohnsonTrotterPermute.cs

* C# implementation of the [Steinhaus-Johnson-Trotter permutation algorithm](https://en.wikipedia.org/wiki/Steinhaus%E2%80%93Johnson%E2%80%93Trotter_algorithm), based also on the explanation by [Ragavan N](https://tropenhitze.wordpress.com/2010/01/25/steinhaus-johnson-trotter-permutation-algorithm-explained-and-implemented-in-java/)
* Optimized with `yield` to avoid initial overhead
* Only 2 public methods:
  * `IEnumerable<IEnumerable<int>> Permute(int count)` returns all permutations of integers between `0` and `count - 1`
  * `IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list)` returns all permutations of the list items

### Known issues

* If a `.ToList()` is applied, all the resulting permutations are equal to the last one
