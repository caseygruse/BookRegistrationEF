﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrationEF
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			List<Book> books = BookDB.GetAllBooks();

			foreach(Book b in books)
			{
				PopulateBookComboBox(books);
			}
		}

		private void PopulateBookComboBox(List<Book> books)
		{
			cboBookList.DataSource = books;
			cboBookList.DisplayMember = "Title";  // title is a string representation of the property I want to display the object with.
												  // nameof(Book.Title);
		}
	}
}
