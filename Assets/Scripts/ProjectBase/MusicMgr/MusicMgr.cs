using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicMgr : BaseManager<MusicMgr>
{
    private AudioSource bkMusic = null;
    private float bkValue = 1;
    private float soundValue = 1;
    private GameObject soundObj = null;

    private List<AudioSource> soundList = new List<AudioSource>();

    public MusicMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(Update);
    }
    private void Update()
    {
        for(int i=soundList.Count-1;i>=0;i--)
        {
            if(!soundList[i].isPlaying)//没有在播放的
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);//在列表中移除
            }
        }
    }

    //播放背景音乐
    public void PlayBKMusic(string name)
    {
        if (bkMusic == null)
        {
            GameObject obj = new GameObject("BKMusic");//创建一个名为BKMusic空物体  
            bkMusic = obj.GetComponent<AudioSource>();
        }
        //异步加载背景音乐并且加载完成后播放
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/bk/" + name, (clip) => { 
            bkMusic.clip = clip;
            bkMusic.loop = true;
            //调整大小
            bkMusic.volume = bkValue;
            bkMusic.Play();
        });//lambda表达式
    }

    //改变背景音量大小
    public void ChangeBKValue(float v)
    {
        bkValue = v;
        if(bkMusic==null)
        {
            return;
        }
        bkMusic.volume = bkValue;
    }
    //暂停背景音乐
    public void PauseBKMusic()
    {
        if(bkMusic==null)
        {
            return;
        }
        bkMusic.Stop();
    }

    //播放音效
    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource>callback=null)
    {
        if(soundObj==null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sounds";
        }
        AudioSource source = soundObj.AddComponent<AudioSource>();
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/Sounds/"+name,(clip)=>{
            source.clip = clip;
            source.loop = isLoop;
            //调整大小
            source.volume = soundValue;
            source.Play();
            //音效资源异步加载结束后，将这个音效组件加入集合中
            soundList.Add(source);
            if(callback!=null)
            {
                callback(source);
            }
        });
    }

    //改变所有音效大小
    public void ChangeSoundValue(float value)
    {
        soundValue = value;
        for(int i = 0;i<soundList.Count;i++)
        {
            soundList[i].volume = value;
        }
    }
    //停止音效
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }
}

