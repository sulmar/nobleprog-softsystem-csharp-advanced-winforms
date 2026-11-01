using System;
using System.Collections.Generic;
using System.Linq;

namespace Lims.Problem
{
    // Symulacja połączenia z bazą: po zamknięciu nie wolno już jej używać.
    public sealed class DbSession : IDisposable
    {
        private bool _disposed;

        public LabResult Find(string code)
        {
            ThrowIfDisposed();
            return ResultDatabase.Instance.Rows.FirstOrDefault(row => row.Code == code);
        }

        public IReadOnlyList<LabResult> Pending()
        {
            ThrowIfDisposed();
            return ResultDatabase.Instance.Rows.Where(row => !row.IsApproved).ToList();
        }

        public int CountApprovedOn(DateTime day)
        {
            ThrowIfDisposed();
            return ResultDatabase.Instance.Rows.Count(row => row.ApprovedAt.HasValue && row.ApprovedAt.Value.Date == day.Date);
        }

        public void Dispose()
        {
            _disposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(DbSession));
            }
        }
    }
}
