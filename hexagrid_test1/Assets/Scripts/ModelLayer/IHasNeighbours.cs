using System.Collections;
//interface that should be implemented by grid nodes used in E. Lippert's generic path finding implementation
using System.Collections.Generic;


public interface IHasNeighbours<N>
{
	IEnumerable<N> Neighbours { get; }
}