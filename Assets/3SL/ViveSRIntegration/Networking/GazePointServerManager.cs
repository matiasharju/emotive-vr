// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using Three.Common;
using Three.ViveSRIntegration.Serialization;
using System.Net;
using System.Text;
using System.Xml;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// Component class to manage the the GazePoint broadcast server and feed it data from the <see cref="ViveSRGazeMonitor"/>.
    /// </summary>
    public class GazePointServerManager : MonoBehaviour {
        // Address on which to listen for client connections.
        // The default value (0.0.0.0) allows connections from any network interface.
        // Consider using the loopback address (127.0.0.1) to restrict connections to only the local machine.
        [Tooltip("Local server address to listen for connections on. iMotions must be able to find this address.")]
        [SerializeField] private string localAddress = IPAddress.Loopback.ToString();

        [Tooltip("Server port to listen on. iMotions must be configured with this port.")]
        [SerializeField] private int port = 4050;

        [Tooltip("Whether or not to log eye data to the Unity console. Helpful for debugging purposes.")]
        [SerializeField] bool doLogging = true;

        private SimpleTcpBroadcastServer server;
        private LogQueue logQueue;

        private GazePointConverter converter;

        private static readonly XmlWriterSettings XML_SETTINGS = new XmlWriterSettings {
            ConformanceLevel = ConformanceLevel.Fragment,
            OmitXmlDeclaration = true,
        };

        [SerializeField] PointOfViewMapper pointOfView;
        
        private void Awake() {
            this.server = new SimpleTcpBroadcastServer(string.IsNullOrWhiteSpace(localAddress) || localAddress == "0.0.0.0" ? IPAddress.Any : IPAddress.Parse(localAddress), port);

            if (doLogging) {
                logQueue = new LogQueue();
                server.SetLogger(logQueue);
            }
        }

        private void Update() {
            logQueue?.Visit();
        }

        private void Send(in GazePointRecord record) {
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb, XML_SETTINGS)) {
                record.ProvideXml(writer);
                writer.Flush();
                server.Broadcast(sb.Append("\r\n").ToString());
            }
        }

        private void OnEnable() {
            server.Open();
            ViveSRGazeMonitor.Instance.OnEyeData += HandleMonitorData;
        }

        private void OnDisable() {
            ViveSRGazeMonitor.Instance.OnEyeData -= HandleMonitorData;
            server.Close();
        }

        private void HandleMonitorData(EyeData_v2 obj) {
            if(converter == null) {
                converter = new GazePointConverter(pointOfView, obj.timestamp);
            }

            if (pointOfView == null) return;
            Send(converter.ConvertToGazePointRecord(obj));
        }

        private void OnDestroy() => server.Dispose();
        private void OnApplicationQuit() => server.Dispose();
    }
}