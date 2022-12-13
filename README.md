# glorified-json-reader
### For reading a json file and displaying it in some fancy way

#### Requirements
- The application expects a file named input.json on the same directory as the .exe (or the .app) file. If such a file does not exist or is incorrectly structured, the application informs the user about the error with a popup.
- The input.json file must be in the same structure with the provided example in the ExampleJSON folder in the project. Although the app can be extended to accept other kinds of json files on further request, it wouldn't make much sense since the app is currently for displaying a board game list.

#### How it works
- GameManager.Start() acts as the main entry point of the program. It reads and deserializes the json file and publishes an event on success.
- GUIManager listens the aforementioned event and sets up the UI elements.

#### Process
- The project took approximately 6 hours of development and 1 hour of testing / fine tuning.
- I used [UniRx](https://github.com/neuecc/UniRx) for publishing and receiving the game events since I initially thought I would use UniRx for its other functionalities as well; however, it seems to be somewhat overkill for this specific project.

#### Screenshot
<img width="1728" alt="Screen Shot 2022-12-14 at 00 32 42" src="https://user-images.githubusercontent.com/37695811/207448505-3192b1a9-8fe8-463d-9ddf-be8b1f578ffa.png">
