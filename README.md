# Food-order

A desktop-based Food Ordering System built with **C#** and **Windows Forms**. This project was developed as a technical demonstration of CRUD operations, file-based data persistence, and UI management in a WinForms environment.

## 🚀 Features

-   **Admin Dashboard**: Full CRUD (Create, Read, Update, Delete) operations for:
    -   **Restaurants**: Manage names, addresses, and contact info.
    -   **Menu Items (Jelo)**: Add dishes with specific weights, descriptions, and associated restaurants.
    -   **Side Dishes (Prilog)**: Configure individual side dish options and pricing.
-   **Data Persistence**: Uses a custom CSV-based "database" system to store and retrieve data locally without requiring a full SQL server.
-   **Validation**: Implements input validation to ensure data integrity (e.g., minimum name lengths, non-empty fields).
-   **GUI**: Intuitive WinForms interface with `DataGridView` for real-time data inspection.

## 🛠️ Technical Stack

-   **Language**: C#
-   **Framework**: .NET (Windows Forms)
-   **Storage**: CSV (Comma Separated Values) for lightweight data management.
-   **Architecture**: Object-Oriented design with dedicated classes for `Restoran`, `Jelo`, `Prilog`, and `Admin` logic.

## 📂 Project Structure

-   `Restoran.cs`: Core logic for restaurant entity management and CSV handling.
-   `Admin.cs`: The administrative controller handling the synchronization between the GUI and the data layer.
-   `Jelo.cs` / `Prilog.cs`: Specific entities for the food and sides.
-   `baza*.csv`: Local files serving as the data storage.

## ⚙️ Setup & Run

1.  Clone the repository.
2.  Open `TVP odbrana.sln` in **Visual Studio**.
3.  Check the file paths in the `*DB` constants (e.g., `RestoranDB` in `Restoran.cs`) and adjust them to your local directory if necessary.
4.  Build and Run the project.

---
*Developed as a part of a technical defensive presentation (TVP) focusing on practical C# application development.*
