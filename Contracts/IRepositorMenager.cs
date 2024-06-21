using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IRepositorMenager
	{
		IUserRepository User{ get; }
		IPostRepository Post { get; }
        ICommentRepository Comment { get; }
        void Save();
	}
}
