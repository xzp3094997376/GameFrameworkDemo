using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using StarForce;
using UnityEngine;

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
}
