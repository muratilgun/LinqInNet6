using System;
using System.Collections.Generic;
using System.Linq;

var names = new[] {"Nick", "Mike","John","Leyla","David","Damian"};

var chunked = names.Chunk(3);

Console.ReadKey();

#region Old
//var chunked = ChunkBy(names, 3);

// IEnumerable<IEnumerable<T>> ChunkBy<T>(IEnumerable<T> source, int chunkSize)
// {
//     return source
//         .Select((x, i) => new { Index = i, Value = x })
//         .GroupBy(x => x.Index / chunkSize)
//         .Select(x => x.Select(v => v.Value));
// }

#endregion