using System;
using UnityEngine;

namespace QFramework
{
    /// <summary>
    /// ��Դ�ļ�����ж��
    /// </summary>
    public class ResourcesRes : Res
    {
        private string mAssetPath;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="assetPath"></param>
        public ResourcesRes(string assetPath)
        {
            mAssetPath = assetPath.Substring("resources://".Length);//ȥ��resources://

            Name = assetPath;//Name��ֵ

            State = ResState.Waiting;//����״̬����
        }

        /// <summary>
        /// Resourcesͬ������
        /// </summary>
        /// <returns></returns>
        public override bool LoadSync()
        {
            State = ResState.Loading;//����״̬����

            Asset = Resources.Load(mAssetPath);//��Դ����

            State = ResState.Loaded;//����״̬����

            return Asset;
        }

        /// <summary>
        /// Resources�첽����
        /// </summary>
        public override void LoadAsync()
        {
            State = ResState.Loading;//����״̬����

            var resRequest = Resources.LoadAsync(mAssetPath);//��Դ�첽����

            resRequest.completed += operation =>
            {
                Asset = resRequest.asset;

                State = ResState.Loaded;                
            };
        }

        /// <summary>
        /// Resourcesж��
        /// </summary>
        protected override void OnReleaseRes()
        {
            if (Asset is GameObject)
            {
                Asset = null;
                
                Resources.UnloadUnusedAssets();
            }
            else
            {
                Resources.UnloadAsset(Asset);
            }

            ResMgr.Instance.SharedLoadedReses.Remove(this);
                
            Asset = null; 
        }
    }
}