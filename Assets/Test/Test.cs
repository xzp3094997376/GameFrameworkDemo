using System.Collections.Generic;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using StarForce;
using UnityEngine;
using UnityGameFramework.Runtime;
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
            //LoadPrefab();
            //PlayMusic();
            //LoadScene();
            //LoadUI();
            //LoadAsset();

            //Test_SaveSetting();
            //Test_ReadSetting();

            //TestEvents();

            TestObjectPool();

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //FireEvent();

            GetPoolObj();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RecyclePoolObj();
        }
    }

    #region Entity
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
        GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset("Test_w"), Constant.AssetPriority.SceneAsset);
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
                GameEntry.Entity.GetEntity(-6).gameObject.GetComponent<MeshRenderer>().material = (Material)asset;
                Log.Info("Load material '{0}' OK.", matAsset);
            },

            (assetName, status, errorMessage, userData) =>
            {
                Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", matAsset, assetName, errorMessage);
            }));
    }
    #endregion


    #region  数据配置

    void Test_SaveSetting()
    {
        GameEntry.Setting.SetInt("CoinNum", 10);
        Debug.Log("金币数量保存");

    }

    /// <summary>
    /// 读取设置
    /// </summary>
    void Test_ReadSetting()
    {
        int coinNum = GameEntry.Setting.GetInt("CoinNum", 0);
        Debug.Log("金币数量读取  " + coinNum);
    }
    #endregion





    #region 事件
    void TestEvents()
    {
        GameEntry.Event.Subscribe(TestEventsArgs.EventId,ReceiveLoadSucess);
        Debug.Log("注册事件");
    }

    void FireEvent()
    {
        GameEntry.Event.Fire(this,TestEventsArgs.Create("Test"));
        Debug.Log("发送事件 "+GameEntry.Event.Count(TestEventsArgs.EventId));
    }
    void ReceiveLoadSucess(object sender,GameEventArgs args)
    {
        TestEventsArgs testEventsArgs = (TestEventsArgs)args;
        string name=(string)testEventsArgs.UserData;
        Debug.Log(" 接受事件 "+name);
    }
    #endregion





    #region 对象池使用

    public ObjectPoolItem m_HPBarItemTemplate;
    private IObjectPool<TestPoolItem> hpbObjectPool;
    List<ObjectPoolItem> ObjectPoolList=new List<ObjectPoolItem>();
    void TestObjectPool()
    {
        int m_InstancePoolCapacity = 3;
        hpbObjectPool = GameEntry.ObjectPool.CreateSingleSpawnObjectPool<TestPoolItem>("HPBarItem", m_InstancePoolCapacity);
        ObjectPoolList.Clear();
    }

    void GetPoolObj()
    {
        ObjectPoolItem hpBarItem = null;
        TestPoolItem hpBarItemObject = hpbObjectPool.Spawn();
        if (hpBarItemObject != null)
        {
            hpBarItem = (ObjectPoolItem)hpBarItemObject.Target;
        }
        else
        {
            hpBarItem = Instantiate(m_HPBarItemTemplate);
            Transform _transform = hpBarItem.GetComponent<Transform>();
            _transform.SetParent(transform);
            _transform.localScale = Vector3.one;
            hpbObjectPool.Register(TestPoolItem.Create(hpBarItem), true);
            ObjectPoolList.Add(hpBarItem);
        }
    }

    void RecyclePoolObj()
    {
        hpbObjectPool.Unspawn(ObjectPoolList[0]);
        ObjectPoolList.RemoveAt(0);

    }
    #endregion


    #region 本地化
    void Localization_Load()
    {
        string dictionaryName = "";
        string dictionaryAssetName = AssetUtility.GetDictionaryAsset(dictionaryName, false);
        GameEntry.Localization.ReadData(dictionaryAssetName, this);
    }

    void LocalizationRead()
    {
        string cancelText = GameEntry.Localization.GetString("Dialog.CancelButton");
    }
    #endregion
}
