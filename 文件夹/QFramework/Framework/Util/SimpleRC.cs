namespace QFramework
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public interface IRefCounter
    {
        int RefCount { get; }

        void Retain(object refOwner = null);

        void Release(object refOwner = null);
    }

    /// <summary>
    /// ���׼�����
    /// </summary>
    public class SimpleRC : IRefCounter
    {
        public int RefCount { get; private set; }

        /// <summary>
        /// ������һ
        /// </summary>
        /// <param name="refOwner"></param>
        public void Retain(object refOwner = null)
        {
            RefCount++;
        }

        /// <summary>
        /// ������һ���ж��Ƿ�Ϊ0
        /// </summary>
        /// <param name="refOwner"></param>
        public void Release(object refOwner = null)
        {
            RefCount--;

            if (RefCount == 0)
            {
                OnZeroRef();
            }
        }

        /// <summary>
        /// ������Ϊ0ʱ���÷���
        /// </summary>
        protected virtual void OnZeroRef()
        {

        }
    }
}