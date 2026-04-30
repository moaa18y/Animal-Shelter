# Animal-Shelter
A console-based C# management system that lets users create, view, update, search, and manage a list of items, Manage animals such as dogs, cats, birds, and small animals with adoption and care records— all through a numbered text menu in the terminal.

# Core Deliverables
1. Console app with a numbered text menu and input validation.
2. Encapsulation: Private fields + public properties on every class.
3. Inheritance: At least 2 subclasses extending an abstract base class.
4. 	Abstract Class: Base class must be abstract with at least 1 abstract method.
5. 	Interface: At least 1 interface with 2+ method signatures.
6. 	Polymorphism: Call the same method on different types — different result each time.
7. 	Apply SOLID Principles.
8. 	File save/load so data persists between runs.


# Brief Flow of the Project

Phase 1: Startup & Injection

1. Boot: The user runs the application (Program.cs).
2. Load Data: Program instantiates AnimalManager (the repository) and ShelterFileHandler. It reads shelter_data.txt and populates the repository with saved animals.
3. Dependency Injection: Program wraps the repository inside AnimalService, then injects that service into AppController. The controller's Run() method is called.


Phase 2: User Interaction (The Controller Loop)

1. Menu: AppController displays the main menu using Console.WriteLine and waits for user input.
2. Validation: ConsoleInput ensures the user types a valid menu number (1-6).


Phase 3: Action Execution (Example: Adding an Animal)

1. Route: User selects 1 (Add Animal). AppController asks what type (Dog, Cat, etc.) and calls AnimalService.AddAnimal().
2. Factory Creation: The Service delegates creation to AnimalFactory. The Factory uses ConsoleInput to ask the user for specific traits (e.g., Breed, Wingspan) and returns a fully built object.
3. Storage: The Service passes the new animal to AnimalManager.Add(). The Manager safely increments the internal ID to prevent conflicts and stores the animal in memory.
4. Feedback: AnimalDisplay shows a green [SUCCESS] message to the user.


Phase 4: Domain Rule Enforcement (Example: Adoption)

1. Route: User selects 4 (Update Status) and tries to adopt an animal.
2. Validation: The request travels from Controller -> Service -> Domain Model (Animal.Adopt()).
3. Domain Security: The Animal class checks its own internal state. If it is Available or PendingAdoption, the adoption succeeds, the status changes, and a timestamped care note is added. If not, it throws an error preventing the action.

Phase 5: Save & Exit

1. Exit Trigger: User selects 6 (Save and Exit). The Controller loop ends.
2. Persist Data: Control returns to Program.cs, which grabs all animals from the repository and passes them to ShelterFileHandler.SaveAll().
3. Write to Disk: The handler dynamically resolves the absolute path to the data folder, translates the data into a pipe-separated string format, and writes it to shelter_data.txt before the application closes.


# State Diagram
<img width="1528" height="1305" alt="State Diagram" src="https://github.com/user-attachments/assets/2e4d2040-6c15-4fb8-a2a8-b12dec48937d" />

# Class Diagram
<img width="1757" height="1498" alt="Class Diagram" src="https://github.com/user-attachments/assets/696e833c-e8e6-47f5-af2a-86edb7c070b5" />
