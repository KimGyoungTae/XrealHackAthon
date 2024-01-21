using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

public class Udpnetwork : MonoBehaviour
{

    public bool send = false;
    public bool push = false;

    private Queue<string> ex1 = new Queue<string>();
    private Queue<string> forsend = new Queue<string>();

    public int painState;

    public string data;

    private static Udpnetwork instance;
    public static Udpnetwork Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = null;
        }
    }
    // 1. Declare Variables
    Thread receiveThread;
    UdpClient client;


    public int myport = 9996;

    public String targetip = "192.168.0.149";
    public int targetport = 8090;
    public string receivemsg;
    IPEndPoint anyIP;


    [Range(0, 1)]
    public float value;


    string sendvalue;


    void Awake()
    {
        if (instance != null)
            //Destroy(gameObject);
            print("start");
        else
            instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    // 2. Initialize variables
    private void Start()
    {
        InitUDP();


    }

    // 3. InitUDP
    private void InitUDP()
    {
        client = new UdpClient(myport); //1
        anyIP = new IPEndPoint(IPAddress.Parse("192.168.0.148"), 0);
        Debug.Log("UDP Initialized");
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // 4. Receive Data
    private void ReceiveData()
    {
        while (true) //2
        {
            try
            {
                //3
                byte[] data = client.Receive(ref anyIP); //4
                receivemsg = Encoding.UTF8.GetString(data); //5
                Debug.Log(receivemsg);
                ex1.Enqueue(receivemsg);
            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
    }

    void Update()
    {
        if (push)
        {
            push = false;
            forsend.Enqueue(data); 
        }

        if (send)
        {
            
            send = false;
            string time = DateTime.Now.ToString(("MM/dd   HH:mm"));
            sendvalue = time + "                     " + painState;
            //sendvalue = forsend.Dequeue();
            //sendvalue = value.ToString();
            Sendmsg(sendvalue);
        }
    }

    void dealqueue()
    {
        while (ex1.Count > 0)
        {
            string receivedmsg = ex1.Dequeue();
            /*-----------
            receive msg가 뭐인지에 따라 수행할 명령어 적기
            -----------*/
        }
    }


    public void Sendmsg(String msg)
    {
        byte[] datagram = Encoding.UTF8.GetBytes(msg);
        Debug.Log(msg);
        client.Send(datagram, datagram.Length, targetip, targetport);
    }

    void OnApplicationQuit()
    {
        client.Close();
        receiveThread.Suspend();
    }
}