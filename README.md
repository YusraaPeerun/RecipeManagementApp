# 🍽️ Recipe Manager Application

A simple and intuitive **Windows Forms (WinForms)** application built with **C# and SQL Server** that allows users to **manage recipes**, including their ingredients, steps, and cost details.

---

## 🚀 Features

### 🧾 Recipe Management
- Add new recipes with name, instructions, category, and creation date.
- Edit existing recipes — update details or change category.
- Delete one or multiple recipes using Ctrl + Click selection.

### 🧂 Ingredient Management
- Add ingredients for each recipe with quantity and cost.
- Automatically calculate and display **total recipe cost**.
- Update or remove ingredients dynamically.

### 🧩 Step Management
- Add, update, or delete recipe preparation steps.
- Steps are auto-numbered in sequence.
- Optional steps — users can leave this section empty.

### 🖼️ Image Support
- Drag and drop a picture directly into the recipe area.
- Uploaded images are stored in the **database** and displayed automatically when selecting a recipe.

### 💰 Price Listing
- Each ingredient includes a cost field.
- The app automatically sums all ingredient costs to show **total recipe price**.

### 🔍 Dynamic Search
- Search recipes instantly using the search bar (`txtSearch`).
- The results filter dynamically as you type.

---

## 🗄️ Database Structure

The application uses **SQL Server** with the following tables:

### **Recipes**
| Column | Type | Description |
|--------|------|-------------|
| RecipeID | int (PK) | Unique identifier |
| RecipeName | nvarchar | Recipe name (unique) |
| Instructions | nvarchar | Cooking instructions |
| Category | nvarchar | Recipe category |
| DateCreated | datetime | Creation date |
| Image | varbinary(max) | Recipe image |

### **Ingredients**
| Column | Type | Description |
|--------|------|-------------|
| IngredientID | int (PK) | Unique identifier |
| RecipeID | int (FK) | Related recipe |
| IngredientName | nvarchar | Ingredient name |
| Quantity | nvarchar | Quantity used |
| Cost | decimal | Cost of the ingredient |

### **Steps**
| Column | Type | Description |
|--------|------|-------------|
| StepID | int (PK) | Unique identifier |
| RecipeID | int (FK) | Related recipe |
| StepNumber | int | Step order number |
| Description | nvarchar | Step instructions |

---

## Tech Stack

- **Language:** C#
- **Framework:** .NET WinForms
- **Database:** SQL Server
- **UI Components:** DataGridView, ComboBox, TextBox, PictureBox
- **Version Control:** Git & GitHub

---

## Future Enhancements

- Export recipes to PDF or Excel.
- Add user authentication.
- Introduce category filtering and sorting.
- Implement image resizing before saving.

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR_USERNAME/RecipeManagerApp.git
