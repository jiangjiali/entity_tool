using System;
using System.Collections.Generic;
using System.Threading;
namespace Dev
{
    public class DisposableObject : IDisposable
    {
        private int m_disposed;

        protected void CheckDisposed()
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(base.GetType().Name);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (Interlocked.CompareExchange(ref this.m_disposed, 1, 0) == 0)
            {
                if (disposing)
                {
                    this.DisposeManaged();
                }
                this.DisposeUnmanaged();
                GC.SuppressFinalize(this);
            }
        }

        protected virtual void DisposeManaged()
        {
        }

        protected virtual void DisposeUnmanaged()
        {
        }

        ~DisposableObject()
        {
            this.Dispose(false);
        }

        public static void SafeDispose<T>(ref T obj) where T : IDisposable
        {
            if (((T)obj) != null)
            {
                obj.Dispose();
                obj = default(T);
            }
        }

        public static void SafeDispose<T>(IEnumerable<T> objects) where T : IDisposable
        {
            if (objects != null)
            {
                foreach (T local in objects)
                {
                    if (local != null)
                    {
                        local.Dispose();
                    }
                }
            }
        }

        public static bool SafeDisposeReturn<T>(ref T obj) where T : IDisposable
        {
            if (((T)obj) != null)
            {
                obj.Dispose();
                obj = default(T);
                return true;
            }
            return false;
        }

        public bool Disposed
        {
            get
            {
                return (this.m_disposed != 0);
            }
        }
    }
}