using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Resource;
using StarForce;
using UnityEngine;
using UnityGameFramework.Runtime;
using Entity = StarForce.Entity;
using GameEntry = StarForce.GameEntry;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadPrefab();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayMusic();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            LoadScene();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadUI();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadAsset();
        }
    }

    [ContextMenu("Do Something")]
    void DoTest()
    {
        Debug.Log("Do SomeThing");
    }

    /// <summary>
    /// 加载实体
    /// </summary>
    void LoadPrefab()
    {

        IDataTable<DRTest> drTabelTest = GameEntry.DataTable.GetDataTable<DRTest>();
        DRTest drTest = drTabelTest.GetDataRow(111111);
        //GameEntry.Entity.ShowEntity();;
        GameEntry.Entity.ShowEntity<TestEntity>(-6, AssetUtility.GetTestAsset(drTest.AssetName), "Test", new TestEntityData(GameEntry.Entity.GenerateSerialId(), 111111, 10000, CampType.Neutral));
    }

    void PlayMusic()
    {
        GameEntry.Sound.PlayMusic(4);
    }


    void LoadScene()
    {
        GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset("Test_w"),Constant.AssetPriority.SceneAsset);
    }

    /// <summary>
    /// 测试UI 
    /// </summary>
    void LoadUI()
    {
        GameEntry.UI.OpenUIForm(UIFormId.TestUIForm, this);
    }

    /// <summary>
    /// 加载普通资源
    /// </summary>
    void LoadAsset()
    {
        string matAsset = "part_test_mat";
        GameEntry.Resource.LoadAsset(AssetUtility.GetMaterialAsset(matAsset), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
            (assetName, asset, duration, userData) =>
            {
                //m_LoadedFlag[Utility.Text.Format("Font.{0}", fontName)] = true;
                //UGuiForm.SetMainFont((Font)asset);
                GameEntry.Entity.GetEntity(-6).gameObject.GetComponent<MeshRenderer>().material=(Material)asset;
                Log.Info("Load material '{0}' OK.", matAsset);
            },

            (assetName, status, errorMessage, userData) =>
            {
                Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", matAsset, assetName, errorMessage);
            }));
    }
}
