# FSRDigitalTwin3D
FSRDigitalTwin3D is a process-oriented simulation environment with semantic reasoning for use cases of social human-robot interaction/collaboration. It consists of a knowledge server to provide semantic reasoning and connected infrastructure (digital layer), and a [Unity simulation tool](https://github.com/Neroware/FSRDigitalTwin3D-Simulation) (virtual layer) to simulate social human-robot collaboration in an interactive 3D-environment using an event-discrete and process-oriented approach.

The design philosophy is to provide a "playground" for virtual robotics simulations abiding to the standards of modern Industry 4.0 applications. Therefore, for external communication, the [AASv3.0/REST](https://industrialdigitaltwin.org/content-hub/standardisierter-digitaler-zwilling-reif-fuer-die-industrie-6208) standard is deployed. The server additionally features a AASv3.0/gRPC API.

**Note:** This digital twin is developed as a sub-project for the research association FORSocialRobots, namely "Subproject 4: Simulation and validation of socially cognitive robots in the digital twin"

*We believe, our digital twin wins the buzzword-bingo of 'Semantic Data Twin' or 'Process Data Twin'...*

## Requirements
This project has OS support for Linux and Windows.

- .NET 8.*
- Unity 2022.3.8f1

## Installation
### Unity Simulation Client (Virtualization Layer)
The client is located at ```/FSR/DigitalTwin/Client/Unity/FSR.DigitalTwin.Client.Unity/```:

1. Navigate to folder ```/FSR/DigitalTwin/Client/Unity/```
2. Load Git submodule ```git submodule update --init --recursive .```
3. Navigate into Unity project ```cd FSR.DigitalTwin.Client.Unity/```
4. Run script ```install-client-plugins```
5. Import the Unity project into Unity Hub and open

### Semantic Data Server (Digitization Layer)
The server solution is located at ```/FSR/DigitalTwin/Server/FSR.DigitalTwin.sln```

1. Navigate to folder ```/FSR/DigitalTwin/Server/tools/```
2. Run script ```install-tools```
3. Load Git submodules ```git submodule update --init --recursive```

## Required Infrastructure

### Semantic Data Repository (Apache Jena)
The semantic data repository is realized through [Apache Jena](https://github.com/apache/jena) querying a knowledge graph through a Fuseki Server. If you want to include or implement services for semantic reasoning, you need to either install Apache Jena Fuseki, or build it from source.

### ROS2 Workspace
If you want to use robot control via ROS2 Humble, set up our [Colcon Workspace](https://github.com/Neroware/FSRDigitalTwin3D).

The repo is linked as a submodule at path ```FSR/DigitalTwin/Server/modules/Ros2Ws```.

## More coming soon!
We are currently working on integrating a discrete-event process simulator into the simulation client. This allows us to simulate a first selection of basic test cases of human-robot interaction...

**Note**: This project is maintained by the [Chair of Digital Manufacturing](https://www.uni-augsburg.de/de/fakultaet/fai/informatik/prof/pi/) of the University of Augsburg.

**Note**: If you have questions or suggestions that are not suitable for discussion within the issues section, feel free to send an e-mail to raoul.zebisch@uni-a.de.

**Licence**: MIT