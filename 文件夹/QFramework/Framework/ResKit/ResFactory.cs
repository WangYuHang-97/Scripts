namespace QFramework
{
    /// <summary>
    /// Res������������Res
    /// </summary>
    public class ResFactory
    {
        /// <summary>
        /// ����Res
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="assetBundleName"></param>
        /// <returns></returns>
        public static Res Create(string assetName, string assetBundleName)
        {
            Res res = null;
            
            if (assetBundleName != null)
            {
                res = new AssetRes(assetName, assetBundleName);//���AssetRes
            }
            else if (assetName.StartsWith("resources://"))//�ֶ���resources://��ʼ
            {
                res = new ResourcesRes(assetName);//���ResourcesRes
            }
            else
            {
                res = new AssetBundleRes(assetName);//���AssetBundleRes
            }

            return res;
        }
    }
}