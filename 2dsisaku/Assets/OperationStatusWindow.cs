using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OperationStatusWindow : MonoBehaviour
{

    [SerializeField]
    private GameObject propertyWindow;
    //　ステータスウインドウの全部の画面
    [SerializeField]
    private GameObject[] windowLists;

    void Update()
    {
        //　ステータスウインドウのオン・オフ
        if (Input.GetButtonDown("Start"))
        {
            propertyWindow.SetActive(!propertyWindow.activeSelf);
            //　MainWindowをセット
            ChangeWindow(windowLists[0]);
        }
    }

    //　ステータス画面のウインドウのオン・オフメソッド
    public void ChangeWindow(GameObject window)
    {
        foreach (var item in windowLists)
        {
            if (item == window)
            {
                item.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                item.SetActive(false);
            }
            //　それぞれのウインドウのMenuAreaの最初の子要素をアクティブな状態にする
            EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").GetChild(0).gameObject);
        }
    }
}